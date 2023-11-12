using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 40f;


    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }
    
}