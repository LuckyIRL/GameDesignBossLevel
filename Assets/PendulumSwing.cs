using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    // Adjust this value to change the speed of the swinging motion
    public float swingSpeed = 1f;
    // Adjust this value to change the damage amount
    public int damageAmount = 10;

    // Set the pivot point of the pendulum
    private Vector3 pivotPoint;

    void Start()
    {
        // Store the initial rotation of the pendulum
        pivotPoint = transform.position;
    }

    void Update()
    {
        // Calculate the rotation angle using a sine wave for pendulum motion
        float angle = Mathf.Sin(Time.time * swingSpeed) * 90f; // 90 degrees is the maximum swing angle

        // Set the new rotation for the pendulum
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Ensure the pendulum remains at the pivot point
        transform.position = pivotPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerBehaviour component of the collided player
            PlayerBehaviour playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();

            // Check if the playerBehaviour is not null
            if (playerBehaviour != null)
            {
                // Damage the player's health using the TakeDamage method of PlayerBehaviour
                playerBehaviour.TakeDamage(damageAmount);
            }
        }
    }
}
