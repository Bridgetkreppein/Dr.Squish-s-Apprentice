using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum ProjectileType { Water, Ball, Glue, ChargedBall }  // Added ChargedBall type
    public ProjectileType projectileType;

    [Header("Projectile Settings")]
    public float speed = 20f;
    public float lifetime = 5f;
    private Rigidbody rb;
    private IProjectileBehavior projectileBehavior;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError($"[Projectile] {gameObject.name} is missing a Rigidbody!");
            return;
        }

        rb.useGravity = false; // Disable gravity

        // Set up behavior based on projectile type
        switch (projectileType)
        {
            case ProjectileType.Water:
                projectileBehavior = gameObject.AddComponent<WaterProjectile>();
                break;
            case ProjectileType.Ball:
                projectileBehavior = gameObject.AddComponent<BallProjectile>();
                break;
            case ProjectileType.Glue:
                projectileBehavior = gameObject.AddComponent<GlueProjectile>();
                break;
            case ProjectileType.ChargedBall:
                projectileBehavior = gameObject.AddComponent<ChargedBallProjectile>();  // Add ChargedBall behavior
                break;
            default:
                Debug.LogError($"[Projectile] {gameObject.name} has an unsupported projectile type!");
                break;
        }
    }

    // Call this to set the direction for the projectile to fly toward
    public void SetDirection(Vector3 targetPoint)
    {
        Vector3 shootDirection = (targetPoint - transform.position).normalized;
        rb.velocity = shootDirection * speed;
        Destroy(gameObject, lifetime); // Destroy after lifetime
    }

    // Collision handling, delegating to specific behavior
    void OnCollisionEnter(Collision collision)
    {
        // Make sure the projectileBehavior has been set
        if (projectileBehavior != null)
        {
            projectileBehavior.OnCollision(collision);
        }
    }
}
