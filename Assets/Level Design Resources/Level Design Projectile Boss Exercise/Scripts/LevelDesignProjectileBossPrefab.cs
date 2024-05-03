using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignProjectileBossPrefab : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private Transform playerPosition;
    public float projectileCooldown;
    public float projectileCount;
    public float fireCooldown;
    public bool canFire;
    public float projectileSpeed;
    public float projectileLifetime;
    public float projectileImpactRadius;
    public float bossViewDistance;
    public GameObject projectilePrefab;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        //faces the boss towards the player with turnSpeed controlling the rotation speed
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - transform.position, Vector3.up), turnSpeed * Time.deltaTime);

        // Fires a raycast to the player of length bossViewDistance to check if the player is detected
        // Raycast is fired from the boss to the player
        RaycastHit hit;
        Debug.Log("Firing Raycast");
        if (Physics.Raycast(transform.position, playerPosition.position - transform.position, out hit, bossViewDistance))
        {
            if (hit.transform.CompareTag("Player") && canFire)
            {
                // If the player is detected, the boss will fire a projectile
                StartCoroutine(FireProjectile());

                // Debug to check if raycast hits the player
                Debug.Log("Hit Player");
            }
        }

    }
    
    IEnumerator FireProjectile()
    {
        Debug.Log("Firing Projectile Coroutine");
        canFire = false;
        //fires a projectileCount amount of projectiles
        for (int i = 0; i < projectileCount; i++)
        {
            //creates a new projectile
            GameObject projectile = Instantiate(projectilePrefab);
            //sets the projectile's position and rotation to the boss's position and rotation
            projectile.transform.position = firePoint.transform.position;
            projectile.transform.rotation = firePoint.transform.rotation;
            projectile.GetComponent<LevelDesignProjectilePrefab>().projectileSpeed = projectileSpeed;
            projectile.GetComponent<LevelDesignProjectilePrefab>().projectileImpactRadius = projectileImpactRadius;
            projectile.GetComponent<LevelDesignProjectilePrefab>().projectileLifetime = projectileLifetime;
            //waits for projectileCooldown amount of time before firing the next projectile
            yield return new WaitForSeconds(projectileCooldown);
        }
        //waits for fireCooldown amount of time before the boss can fire again
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, playerPosition.position - transform.position);
        // Draw a sphere to show the bossViewDistance
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, bossViewDistance);
    }
}
