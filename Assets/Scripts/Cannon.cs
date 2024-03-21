using UnityEngine;

public class CannonFire3D : MonoBehaviour
{
    public GameObject ballPrefab; // Reference to the ball prefab to be fired
    public Transform firePoint; // Reference to the point from where the ball will be fired
    public AudioClip fireSound; // Sound to play when firing

    public float fireForce = 10f; // Force to apply to fire the ball
    public float fireAngleX = 45f; // Angle at which the ball is fired along the X axis
    public float fireAngleY = 0f; // Angle at which the ball is fired along the Y axis
    public float fireDelay = 1f; // Delay between shots

    private AudioSource audioSource; // Reference to the AudioSource component
    private float nextFireTime; // Time when the cannon can fire next

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        nextFireTime = 0f; // Initialize nextFireTime
    }

    void Update()
    {
        // Check if the player presses the "E" key and if it's time to fire
        //if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextFireTime)
       // {
           // Fire();
      //  }
    }

    public void Fire()
    {
        // Play the fire sound effect
        if (audioSource != null && fireSound != null)
        {
            audioSource.PlayOneShot(fireSound);
        }

        // Check if ballPrefab and firePoint are assigned
        if (ballPrefab != null && firePoint != null)
        {
            // Instantiate a new ball at the firePoint position
            GameObject ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);

            // Get the Rigidbody component of the instantiated ball
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            // Check if Rigidbody component exists
            if (rb != null)
            {
                // Calculate the direction to fire
                Vector3 fireDirection = Quaternion.Euler(fireAngleX, fireAngleY, 0) * firePoint.forward;

                // Apply force to fire the ball
                rb.AddForce(fireDirection * fireForce, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found on the ball prefab.");
            }
        }
        else
        {
            Debug.LogWarning("Ball prefab or fire point not assigned.");
        }

        // Update nextFireTime to delay the next shot
        nextFireTime = Time.time + fireDelay;
    }
}
