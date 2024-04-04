using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignProjectilePrefab : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileImpactRadius;
    public float projectileLifetime;

    public GameObject explosionVisuals;

    // Start is called before the first frame update
    void Start()
    {
        // Destroys the projectile after projectileLifetime amount of time
        Destroy(gameObject, projectileLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the projectile forward
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }

    // Checks if the projectile collides with an object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If the projectile collides with the player, the player will take damage
            PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
            if (playerBehaviour != null)
            {
                playerBehaviour.TakeDamage(10); // Adjust the damage value as needed
                Debug.Log("Player Hit!");
            }

            // Perform explosion and destroy the projectile
            Explode();
        }
        else if (other.CompareTag("Boss")) // If the projectile collides with a boss, do nothing
        {
            return;
        }
        else // If the projectile collides with any other object, explode
        {
            Explode();
        }
    }

    void Explode()
    {
        Debug.Log("Exploded");
        // Creates a sphere at the projectile's position with a radius of projectileImpactRadius
        Collider[] colliders = Physics.OverlapSphere(transform.position, projectileImpactRadius);

        if (explosionVisuals != null)
        {
            Instantiate(explosionVisuals, transform.position, transform.rotation); // If there is an explosionVisuals object, it will be instantiated
        }

        // Destroys the projectile
        Destroy(gameObject);
    }
}
