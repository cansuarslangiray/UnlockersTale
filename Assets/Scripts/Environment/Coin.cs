using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.gameObject.CompareTag("Player"))
        {
            
            Player.Coins++;
            Destroy(gameObject);
        }
    }
}
