using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricButton : MonoBehaviour
{
    public MoveObjectOnTrigger moveObjectOnTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Debug check

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the button!"); // Confirm player collision
            if (moveObjectOnTrigger != null)
            {
                Debug.Log("Starting movement loop..."); // Confirm method call
                moveObjectOnTrigger.StartMoveLoop();
            }
            else
            {
                Debug.LogError("MoveObjectOnTrigger is not assigned in Inspector!");
            }
        }
    }
}