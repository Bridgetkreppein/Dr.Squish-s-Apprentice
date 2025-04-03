using UnityEngine;

public class WaterProjectile : MonoBehaviour, IProjectileBehavior
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Use continuous collision detection for high-speed objects
        }
    }

    public void OnCollision(Collision collision)
    {
        // Handle water-specific behavior
        Debug.Log("Water projectile collided!");

        // Check if the object that was hit has the "Slime" tag
        if (collision.gameObject.CompareTag("Slime"))
        {
            // Destroy the Slime object
            Destroy(collision.gameObject);
            Debug.Log("Water projectile hit a Slime and destroyed it!");
        }

        // Destroy the water projectile itself after impact
        Destroy(gameObject);
    }
}