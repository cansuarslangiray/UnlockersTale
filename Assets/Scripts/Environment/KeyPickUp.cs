using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyPanel;
    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.CollectedKey();
            gameObject.SetActive(false); // key disappears when player touch it

            keyPanel.SetActive(true);
            

        }
        
        
    }
}
