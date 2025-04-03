using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfCollectibles {get; private set; }

   public void CollectibleCollected()
   {
        NumberOfCollectibles++;
   }
}
