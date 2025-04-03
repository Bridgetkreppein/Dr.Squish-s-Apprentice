using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public Room1ObjectiveHandler objectiveHandler;  // Reference to the Room1ObjectiveHandler script
    public UIManager uiManager;  // Reference to the UIManager script to update the UI

    [SerializeField] private AudioClip keyPickupSound; // Sound effect for collecting the key
    [SerializeField] private AudioSource audioSource;  // Audio source to play the sound

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the key object
        if (other.CompareTag("Key"))
        {
            objectiveHandler.OnKeyCollected();  // Notify that the key has been collected
            
            // Debugging: Check if AudioSource and Clip are assigned
            if (audioSource == null)
            {
                Debug.LogError("AudioSource is not assigned in KeyCollector!");
            }
            if (keyPickupSound == null)
            {
                Debug.LogError("Key pickup sound is not assigned in KeyCollector!");
            }

            // Play sound effect if everything is assigned
            if (audioSource != null && keyPickupSound != null)
            {
                Debug.Log("Playing key pickup sound...");
                AudioSource.PlayClipAtPoint(keyPickupSound, Camera.main.transform.position);
            }

            Destroy(other.gameObject);  // Destroy the key object after collection

            if (uiManager != null)
            {
                uiManager.UpdateKeyUI(true);  // Update the UI to show key has been collected
            }
        }
    }
}
