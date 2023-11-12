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
    [SerializeField] private GameObject[] vehiclePrefabs;
    public GameObject destroyGameObject;
    public GameObject destoyObsticel;
    public float leftBound = -20f;
    public float rightBound = 20f;
    private bool _isCompleted;
    private int _loopCounter = 0;
    private int _index;



    void Update()
    {
        if (!_isCompleted)
        {
            UpdatePlatform(); }
    }

    private void GenerateSection()
    {
        secNumber = Random.Range(0, 2);
        zPosition += 150;
        var platform = Instantiate(section[secNumber], new Vector3(0, 0, zPosition), Quaternion.identity);
        platform.transform.SetParent(destroyGameObject.transform);
        Destroy(destroyGameObject.transform.GetChild(0).gameObject);
        SpawnRandomVehicle(zPosition);
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

    private void CreatingObsticle()
    {
        
    }

    private void SpawnRandomVehicle(int zAxis)
    {
        _index = Random.Range(0, vehiclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, zAxis);
        Instantiate(vehiclePrefabs[_index], spawnPos, Quaternion.Euler(0, 180, 0));
        
    }
}

