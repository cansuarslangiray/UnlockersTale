using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GeneratePlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private int zPosition = 300;
    [SerializeField] private int secNumber;
    [SerializeField] private GameObject player;
    [SerializeField] private float playerPosition;
    public GameObject destroyGameObject;
    private bool _isCompleted;
    private int _loopCounter = 0;


    void Update()
    {
        if (!_isCompleted)
        {
            UpdatePlatform();
        }
    }

    private void GenerateSection()
    {
        secNumber = Random.Range(0, 2);
        zPosition += 150;
        var platform = Instantiate(section[secNumber], new Vector3(0, 0, zPosition), Quaternion.identity);
        platform.transform.SetParent(destroyGameObject.transform);
        Destroy(destroyGameObject.transform.GetChild(0).gameObject);
    }

    private void UpdatePlatform()
    {
        if (player.transform.position.z >= playerPosition)
        {
            _loopCounter++;
            playerPosition += 150;
            GenerateSection();
        }

        if (_loopCounter == 2)
        {
            _isCompleted = true;
        }
    }
}

