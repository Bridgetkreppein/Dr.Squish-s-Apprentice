using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("References")]
    public MoveObjectOnTrigger platformScript;
    private bool isActivated = false; // Track if it has been activated

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player")) // Activate only once
        {
            isActivated = true;
            platformScript.StartMoveLoop();
        }
    }
}
