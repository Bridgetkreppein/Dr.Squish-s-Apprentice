using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    public GameObject tool; // Reference to the tool (weapon) object
    public Transform handTransform; // Reference to the player's hand transform where the tool will be equipped
    private bool isPlayerInRange = false; // Flag to check if the player is in range
    private Transform playerTransform; // Store the player's transform

    void Start()
    {
        // Ensure the tool is disabled at the start if it's not equipped
        if (tool != null)
        {
            tool.SetActive(false);
        }
    }

    void Update()
    {
        // Equip the tool only when the player is in range and presses 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            EquipTool(true); // Equip the tool
            Debug.Log("Tool picked up and equipped!"); // Debug log when the tool is picked up
        }
    }

    // When the player enters the collider range
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform; // Store reference to player's transform
            isPlayerInRange = true;
        }
    }

    // When the player leaves the collider range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            playerTransform = null; // Clear the reference when the player leaves
        }
    }

    // Method to equip the tool
    private void EquipTool(bool equip)
    {
        if (equip)
        {
            // Check if the tool object is assigned and active
            if (tool != null)
            {
                // Ensure the tool is active before equipping
                tool.SetActive(true);  // Activate the tool object

                // Attach the tool to the player's hand (set parent to handTransform)
                tool.transform.SetParent(handTransform);  
                
                // Reset the tool's position and rotation relative to the hand
                tool.transform.localPosition = Vector3.zero; // Adjust this as necessary to fit the hand position
                tool.transform.localRotation = Quaternion.identity; // Adjust rotation to fit the hand

                // Optionally, reset scale if needed
                tool.transform.localScale = Vector3.one; 
            }
            else
            {
                Debug.LogError("Tool object is not assigned in the inspector!");
            }
        }
    }
}