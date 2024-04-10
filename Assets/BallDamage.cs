using UnityEngine;

public class BallDamage : MonoBehaviour
{
    public int damageAmount = 10; // Adjust this value to change the damage amount
    public float collisionForce = 50f; // Adjust this value to change the collision force

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Apply a force to the player's Rigidbody component to push them away
                Vector3 forceDirection = (collision.contacts[0].point - transform.position).normalized;
                playerRigidbody.AddForce(forceDirection * collisionForce, ForceMode.Impulse);
            }

            // Damage the player's health
            PlayerBehaviour playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (playerBehaviour != null)
            {
                playerBehaviour.TakeDamage(damageAmount);
            }

            // Destroy the ball when it hits the player
            Destroy(gameObject);
        }
    }
}
