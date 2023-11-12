using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float amplitude = 0.1f; // the wideness of movement
    public float speed = 2.0f; // movement speed
    private Vector3 initialPosition; 

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float sinValue = Mathf.Sin(Time.time * speed);
        Vector3 offset = Vector3.up * sinValue * amplitude;

        // new position 
        transform.position = initialPosition + offset;
    }
}
