using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,2,-3);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() //LateUpdate provides smooth moves of camera 
    {
        //offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}