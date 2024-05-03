using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] public Healthbar _healthbar;
    public float cannon_balls_collected;
    private Vector3 startpointPos;
    public bool is_dead;


    void Start()
    {
        // Set the initial health of the player in the health bar
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        Debug.Log("Player Health: " + GameManager.gameManager._playerHealth.Health);
        startpointPos = transform.position;
    }

    private void Update()
    {
        if (GameManager.gameManager._playerHealth.Health <= 0)
        {
            is_dead = true;
            GameManager.gameManager._playerHealth.Health = 100;
            _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        }
    }

    // Method to take damage when hit by the boss
    public void TakeDamage(int damageAmount)
    {
        GameManager.gameManager._playerHealth.DmgUnit(damageAmount);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        Debug.Log("Player Health: " + GameManager.gameManager._playerHealth.Health);
    }




    // Method to heal the player when collecting a health pickup
    public void Heal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }
    public void lose_cannonball()
    {
        cannon_balls_collected -= 1;
    }
}
