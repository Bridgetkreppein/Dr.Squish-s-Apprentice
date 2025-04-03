using UnityEngine;

public class GlueProjectile : MonoBehaviour, IProjectileBehavior
{
    public GameObject gluePrefab; // Reference to the glue prefab (set this in the Inspector)

    public void OnCollision(Collision collision)
    {
        Debug.Log("Glue projectile collided with: " + collision.gameObject.name);

        // Check if the object that was hit has the "Repair" tag
        if (collision.gameObject.CompareTag("Repair"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Glue projectile hit a Repair object and destroyed it!");
        }

        if (gluePrefab != null)
        {
            // Offset slightly above the collision point to prevent z-fighting or overlapping
            Vector3 spawnPoint = collision.contacts[0].point + Vector3.up * 0.1f;
            Instantiate(gluePrefab, spawnPoint, Quaternion.identity);
            Debug.Log("Glue prefab instantiated at: " + spawnPoint);
        }
        else
        {
            Debug.LogError("Glue prefab is not assigned in the Inspector!");
        }

        // Destroy the projectile after the collision
        Destroy(gameObject);
        Debug.Log("Glue projectile destroyed after impact.");
    }
}