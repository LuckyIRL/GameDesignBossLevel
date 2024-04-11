using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject giantBallPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public float downwardForce = 2f;
    public int damageAmount = 10; // Adjust this value to change the damage amount

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBall();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnBall()
    {
        GameObject newBall = Instantiate(giantBallPrefab, spawnPoint.position, Quaternion.identity);

        // Attach the BallDamage script to the spawned ball
        BallDamage ballDamage = newBall.AddComponent<BallDamage>();
        ballDamage.damageAmount = damageAmount;

        Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            // Apply a small downward force to the ball to ensure it starts falling
            ballRigidbody.AddForce(Vector3.down * downwardForce, ForceMode.Impulse);
        }
    }
}
