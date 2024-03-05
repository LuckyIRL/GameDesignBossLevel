using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Destroy the cannonball when it collides with something in the scene
        Destroy(gameObject);
    }
}
