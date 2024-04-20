using UnityEngine;

public class Dart : MonoBehaviour
{
    // Variables for the dart's speed, force forwards, and damage amount
    public float dartSpeed = 10f;
    public int damageAmount = 10;
    public float forceForward = 1000f;

    void Start()
    {
        // Add a force to the dart to move it forwards
        GetComponent<Rigidbody>().AddForce(transform.forward * forceForward);
    }




    void OnTriggerEnter(Collider other)
    {
        // Check if the dart collides with the player
        if (other.CompareTag("Player"))
        {
            // Get the PlayerBehaviour component of the collided player
            PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();

            // Check if the playerBehaviour is not null
            if (playerBehaviour != null)
            {
                // Damage the player's health using the TakeDamage method of PlayerBehaviour
                playerBehaviour.TakeDamage(damageAmount);
            }

            // Destroy the dart after hitting the player
            Destroy(gameObject);
        }
    }
}