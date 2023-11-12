using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter1 : MonoBehaviour
{
    public Transform point; // the point that will be followed - player

    public float distance = 3.0f; // the difference between camera and player
    public float height = 1.0f; // height of camera

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (point == null)
        {
            return;
        }

        Vector3 pointPos = point.position + Vector3.up * height;

        transform.position = pointPos - point.forward * distance;

        transform.LookAt(pointPos); 
    }
}
