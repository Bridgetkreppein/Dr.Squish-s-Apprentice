using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Make sure you have TextMeshPro imported

public class UIManager : MonoBehaviour
{
    public TMP_Text objectiveText;  // Reference to your TMP text UI element for the main objective
    public TMP_Text objectiveCountText;  // Reference to your TMP text UI element for the count of completed objectives
    public TMP_Text keyCollectedText;  // Reference to display key collected status (optional)
    public TMP_Text chargeAmmoText;  // New reference to display ChargeAmmo status (new UI text element)

    void Start()
    {
        // Get the Room1ObjectiveHandler component
        Room1ObjectiveHandler objectiveHandler = FindObjectOfType<Room1ObjectiveHandler>();

        if (objectiveHandler != null)
        {
            // Subscribe to the OnObjectiveCompleted event
            objectiveHandler.OnObjectiveCompleted += HandleObjectiveCompleted;

            // Initialize the UI
            UpdateObjectiveUI(objectiveHandler); // Update the UI with the current state
        }
        else
        {
            Debug.LogError("Room1ObjectiveHandler is missing from the scene!");
        }
    }

    // This method is called when the objective is completed
    private void HandleObjectiveCompleted()
    {
        Room1ObjectiveHandler objectiveHandler = FindObjectOfType<Room1ObjectiveHandler>();
        if (objectiveHandler != null)
        {
            UpdateObjectiveUI(objectiveHandler);
        }
    }

    // Method to update both the main objective text and the completed objectives count
    private void UpdateObjectiveUI(Room1ObjectiveHandler objectiveHandler)
    {
        if (objectiveHandler != null)
        {
            if (objectiveText != null)
            {
                objectiveText.text = "Objective: Fix Rooms";
            }
            else
            {
                Debug.LogWarning("Objective Text is not assigned in UIManager.");
            }

            if (objectiveCountText != null)
            {
                int completedCount = objectiveHandler.GetCompletedObjectivesCount();
                objectiveCountText.text = "Rooms Fixed: " + completedCount.ToString();
            }
            else
            {
                Debug.LogWarning("Objective Count Text is not assigned in UIManager.");
            }
        }
        else
        {
            Debug.LogError("Objective Handler is null. Cannot update UI.");
        }
    }

    // Method to update key collected UI (called when the key is collected)
    public void UpdateKeyUI(bool keyCollected)
    {
        if (keyCollectedText != null)
        {
            keyCollectedText.text = keyCollected ? "Handle Collected!" : "Key Not Collected";
        }
        else
        {
            Debug.LogWarning("Key Collected Text is not assigned in UIManager.");
        }
    }

    // New method to update ChargeAmmo UI status
    public void UpdateChargeAmmoUI(bool chargeAmmoCollected)
    {
        if (chargeAmmoText != null)
        {
            chargeAmmoText.text = chargeAmmoCollected ? "Supercharge Activated!" : "ChargeAmmo Needed";
        }
        else
        {
            Debug.LogWarning("ChargeAmmo Text is not assigned in UIManager.");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed to prevent memory leaks
        Room1ObjectiveHandler objectiveHandler = FindObjectOfType<Room1ObjectiveHandler>();
        if (objectiveHandler != null)
        {
            objectiveHandler.OnObjectiveCompleted -= HandleObjectiveCompleted;
        }
    }
}
