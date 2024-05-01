using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] public Healthbar _healthbar;
    public float cannon_balls_collected;
    private Vector3 startpointPos;

    void Start()
    {
        // Set the initial health of the player in the health bar
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        startpointPos = transform.position;
    }

    // Method to take damage when hit by the boss
    public void TakeDamage(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);

        // Check if player's health reaches zero
        if (GameManager.gameManager._playerHealth.Health <= 0)
        {
            GameManager.gameManager.StartCoroutine(GameManager.gameManager.Respawn(.5f));
        }
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
