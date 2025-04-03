using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NPCInteractionTrigger : MonoBehaviour
{
    [Header("UI Image that appears during interaction")]
    public GameObject dialogueImage; // Assign in Inspector

    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detect Player entering trigger
        {
            canInteract = true;
            Debug.Log("Player entered NPC interaction zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Detect Player leaving trigger
        {
            canInteract = false;
            dialogueImage.SetActive(false); // Hide dialogue when leaving
            Debug.Log("Player left NPC interaction zone. Hiding dialogue.");
        }
    }

    // Method for PlayerInput component (must be public and parameterless)
    public void OnInteract()
    {
        if (canInteract)
        {
            bool isActive = !dialogueImage.activeSelf;
            dialogueImage.SetActive(isActive);
            Debug.Log("Interaction button pressed. Dialogue UI " + (isActive ? "shown." : "hidden."));
        }
    }
}