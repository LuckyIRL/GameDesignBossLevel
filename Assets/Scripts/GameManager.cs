using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(100, 100);
    private Vector3 startpointPos;
    private Rigidbody playerRB;
    PlayerBehaviour playerBehaviour;

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject); // Don't destroy the GameManager when loading new scenes
        }
    }

    void Start()
    {
        startpointPos = GameObject.FindGameObjectWithTag("Player").transform.position; // Find the player's starting position
        // Find the player's Rigidbody component
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    public IEnumerator Respawn(float delay)
    {
        // Disable the player's Rigidbody component
        //playerRB.isKinematic = true;
        // Wait for the delay time
        yield return new WaitForSeconds(delay);
        // Reset the player's health
        _playerHealth.Health = _playerHealth.MaxHealth;
        // Update the health bar
        playerBehaviour._healthbar.SetHealth(_playerHealth.Health);
        // Set the player's position to the starting position
        GameObject.FindGameObjectWithTag("Player").transform.position = startpointPos;
        // Enable the player's Rigidbody component
        //playerRB.isKinematic = false;
    }
}
