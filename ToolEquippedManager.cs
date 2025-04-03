using UnityEngine;

public class ToolEquippedManager : MonoBehaviour
{
    // This flag will track if the tool is equipped
    private bool isToolEquipped = false;

    // Method to equip the tool
    public void EquipTool(bool equipped)
    {
        isToolEquipped = equipped;
        Debug.Log("ToolEquippedManager: Tool equipped status changed to " + isToolEquipped);
    }

    // Method to check if the tool is equipped
    public bool IsToolEquipped()
    {
        return isToolEquipped;
    }
}

