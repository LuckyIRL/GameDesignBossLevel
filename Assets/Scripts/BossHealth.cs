using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public UnityEvent OnBossDied;

    public UnityEvent onHealthChanged;

    public DoorController leftDoorController;
    public DoorController rightDoorController;

    void Start()
    {
        _currentHealth = _maximumHealth;
    }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public void TakeDamage()
    {
        _currentHealth -= 6;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnBossDied.Invoke();
        }

        onHealthChanged.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            TakeDamage();
        }
    }

    public void BossDied()
    {
        // Open both doors
        leftDoorController.OpenDoor();
        rightDoorController.OpenDoor();
    }
}
