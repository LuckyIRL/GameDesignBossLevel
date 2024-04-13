using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healingAmount = 20; // Adjust the healing amount as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
            if (playerBehaviour != null)
            {
                playerBehaviour.Heal(healingAmount); // Call the Heal method of the PlayerBehaviour script
                Debug.Log("Player healed!"); // Optionally, log a message to indicate that the player was healed
            }

            // Destroy the collectible after it has been collected
            Destroy(gameObject);
        }
    }
}
