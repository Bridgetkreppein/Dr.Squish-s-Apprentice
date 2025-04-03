using UnityEngine;
using System.Collections;  // Add this line to fix the IEnumerator issue

public class Room1ObjectiveHandler : MonoBehaviour
{
    private int completedObjectivesCount = 0;  
    private bool hasKey = false;  

    public GameObject FX;  // Reference to the FX GameObject (with particle system)

    public delegate void ObjectiveCompleted();
    public event ObjectiveCompleted OnObjectiveCompleted;

    public void OnKeyCollected()
    {
        hasKey = true;
        Debug.Log("Key collected.");
    }

    public void OnKeyPlacedInSlot()
    {
        Debug.Log("Key placed in KeySlot.");
    }

    public bool HasKey()
    {
        return hasKey;
    }

    public void IncrementObjectiveCount()
    {
        completedObjectivesCount++;
        Debug.Log("Objective complete! Total: " + completedObjectivesCount);

        // Activate the particle system
        if (FX != null)
        {
            FX.SetActive(true);
            ParticleSystem particleSystem = FX.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
                StartCoroutine(WaitForParticleSystem(particleSystem));
            }
            else
            {
                Debug.LogWarning("No ParticleSystem found on FX GameObject.");
            }
        }

        OnObjectiveCompleted?.Invoke();
    }

    private IEnumerator WaitForParticleSystem(ParticleSystem particleSystem)
    {
        yield return new WaitForSeconds(particleSystem.main.duration);

        // Destroy the particle system once it's done
        Destroy(FX);

        // Optionally: Play a sound here if desired

        // Activate "You Win" canvas (if you have one)
        // Assuming you have a win canvas set elsewhere
        // winCanvas.SetActive(true);
    }

    public int GetCompletedObjectivesCount()
    {
        return completedObjectivesCount;
    }
}
