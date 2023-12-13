using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float speedIncreaseInterval = 50.0f;
    public float speedIncreaseAmount = 1.0f;
    public float maxSpeed = 45.0f;
    private float _timer;

    private void Start()
    {
        player = GameObject.Find("Player");
        _timer = 0f;
    }

    void Update()
    {
        if (player.transform.position.z - 45 > transform.position.z)
        {
            Destroy(gameObject);
        }
        _timer += Time.deltaTime;

        // Check if it's time to increase speed.
        if (_timer >= speedIncreaseInterval)
        {
            speed += speedIncreaseAmount;

            speed = Mathf.Min(speed, maxSpeed);

            _timer = 0f;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
    
}
