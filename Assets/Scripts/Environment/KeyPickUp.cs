using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.CollectedKey();
            gameObject.SetActive(false); // key disappears when player touch it
        }
        

    }
}
