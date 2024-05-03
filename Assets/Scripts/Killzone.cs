using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    public PlayerBehaviour player;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(200);
        }
    }
}

