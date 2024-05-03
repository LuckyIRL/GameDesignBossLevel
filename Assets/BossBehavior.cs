using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float detectionRange = 10f;
    public float projectileSpeed = 10f;
    public float shootCooldown = 2f;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    private Transform player;
    private float lastShootTime;
    public bool canFire = true;
    public float turnSpeed = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //faces the boss towards the player with turnSpeed controlling the rotation speed
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position, Vector3.up), turnSpeed * Time.deltaTime);

        // Fires a raycast to the player of length bossViewDistance to check if the player is detected
        // Raycast is fired from the boss to the player
        RaycastHit hit;
        Debug.Log("Firing Raycast");
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, detectionRange))
        {
            if (hit.transform.CompareTag("Player") && canFire)
            {
                // If the player is detected, the boss will fire a projectile
                ShootAtPlayer();

                // Debug to check if raycast hits the player
                Debug.Log("Hit Player");
            }
        }

    }

    void ShootAtPlayer()
    {
        // Check if enough time has passed since the last shoot
        if (Time.time - lastShootTime > shootCooldown)
        {
            // Instantiate projectile prefab and set its direction towards the player
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Vector3 direction = (player.position - shootPoint.position).normalized;
            projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;

            // Update last shoot time
            lastShootTime = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, player.position - transform.position);
    }
}
