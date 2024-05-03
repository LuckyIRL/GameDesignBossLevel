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
    [SerializeField] public GameObject particle;
    //[SerializeField] public AudioClip hitSound;
    //[SerializeField] public AudioClip explosion;

    public UnityEvent onHealthChanged;

    public Animator leftDoorController;
    public Animator rightDoorController;

    void Start()
    {
        _currentHealth = _maximumHealth;
        leftDoorController = GameObject.Find("LeftDoor").GetComponent<Animator>();
        rightDoorController = GameObject.Find("RightDoor").GetComponent<Animator>();
        particle = GameObject.Find("BigExplosion");
        //explosion = GameObject.Find("Explosion").GetComponent<AudioClip>();
        //hitSound = GameObject.Find("HitSound").GetComponent<AudioClip>();

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
            //AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
    }

    public void BossDied()
    {
        
        
        // Play the animation for the doors to open
        leftDoorController.SetBool("Open", true);
        rightDoorController.SetBool("Open", true);
        // Play the particle effect
        //Instantiate(particle, transform.position, Quaternion.identity);
        // Play the explosion sound
        //AudioSource.PlayClipAtPoint(explosion, transform.position);
    }
}
