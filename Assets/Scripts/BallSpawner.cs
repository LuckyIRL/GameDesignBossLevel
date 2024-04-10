using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject giantBallPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public float downwardForce = 2f;
    public int damageAmount = 10; // Adjust this value to change the damage amount
    public float collisionForce = 50f; // Adjust this value to change the collision force

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

        // Set a higher mass for the ball Rigidbody
        Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
        ballRigidbody.mass = 1000f; // Adjust this value as needed

        // Attach the BallDamage script to the spawned ball
        BallDamage ballDamage = newBall.AddComponent<BallDamage>();
        ballDamage.damageAmount = damageAmount;

        if (ballRigidbody != null)
        {
            // Apply a small downward force to the ball to ensure it starts falling
            ballRigidbody.AddForce(Vector3.down * downwardForce, ForceMode.Impulse);
        }
    }
}
