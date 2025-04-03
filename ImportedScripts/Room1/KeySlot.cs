using System.Collections;
using UnityEngine;

public class KeySlot : MonoBehaviour
{
    public Room1ObjectiveHandler objectiveHandler;  // Reference to the objective handler
    public bool isUnlocked = false;  // Flag to check if the KeySlot is unlocked
    public GameObject objectToActivate;  // Object to activate once the key is placed
    public GameObject winCanvas;  // "You Win" canvas panel

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUnlocked)
        {
            if (objectiveHandler.HasKey())  
            {
                UnlockKeySlot();
                Debug.Log("Player has brought the key to the KeySlot. KeySlot unlocked!");
            }
            else
            {
                Debug.Log("You need the key to unlock this slot.");
            }
        }
    }

    void UnlockKeySlot()
    {
        isUnlocked = true;
        objectiveHandler.OnKeyPlacedInSlot();

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);  // Activate the object when unlocked
        }

        // Start the coroutine to handle the win screen after a delay
        StartCoroutine(WaitAndShowWinScreen());
    }

    IEnumerator WaitAndShowWinScreen()
    {
        // Wait for 1 second after activating the object
        yield return new WaitForSeconds(1f);

        // Show the win screen
        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }

        // Optionally, you could increment the objective count here if needed
        objectiveHandler.IncrementObjectiveCount();
    }
}