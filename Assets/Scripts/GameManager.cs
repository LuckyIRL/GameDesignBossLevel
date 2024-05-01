using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(100, 100);
    private Vector3 checkpointPos;
    private Rigidbody playerRB;
    PlayerBehaviour playerBehaviour;
    //MeshRenderer playerMesh;

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
        checkpointPos = GameObject.FindGameObjectWithTag("Player").transform.position; // Find the player's starting position
        // Find the player's Rigidbody component
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        //playerMesh = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
    }

    public void UpdateCheckpoint(Vector3 pos)
    {
        // Update the checkpoint position
        checkpointPos = pos;
    }

    public IEnumerator Respawn(float delay)
    {
        // enable the player's mesh renderer
        //playerMesh.enabled = true;
        // Disable the player's Rigidbody component
        //playerRB.isKinematic = true;
        // Wait for the delay time
        yield return new WaitForSeconds(delay);
        // Reset the player's health
        _playerHealth.Health = _playerHealth.MaxHealth;
        // Update the health bar
        playerBehaviour._healthbar.SetHealth(_playerHealth.Health);
        // Set the player's position to the starting position
        GameObject.FindGameObjectWithTag("Player").transform.position = checkpointPos;
        // Enable the player's Rigidbody component
        //playerRB.isKinematic = false;
    }
}
