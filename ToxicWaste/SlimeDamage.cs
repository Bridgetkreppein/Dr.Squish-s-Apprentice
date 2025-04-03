using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    public int damage = -1; // Amount of damage the slime does

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage); // Deal damage to the player via the PlayerController
            }
        }
    }
}