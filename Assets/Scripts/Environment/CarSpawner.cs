using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;

    public Material[] carColors;

    public GameObject player;
    public GameObject carContainer;

    public float spawnInterval;

    public float currentSpawnPosition;

    public float targetPlayerPosition;

    public float[] availableXPositions = new float[] { -1.7f, 0, 1.7f };

    public int maxSamePosCount;

    public int samePosCount;

    public float lastXPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        maxSamePosCount = 3;
        spawnInterval = 10f;
        targetPlayerPosition = player.transform.position.z + 10;
        currentSpawnPosition = 90;
        InitializeSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerPosition();
    }

    private void InitializeSpawner()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnCar();
        }
    }

    private void CheckPlayerPosition()
    {
        spawnInterval = 10 - player.GetComponent<Player>().currentSpeed / 4;
        if (player.transform.position.z >= targetPlayerPosition)
        {
            if (currentSpawnPosition <= 700)
            {
                targetPlayerPosition += spawnInterval;
                SpawnCar();
            }
        }
    }

    private void SpawnCar()
    {
        var randomCar = carPrefabs[Random.Range(0, carPrefabs.Length)];
        var spawnPosition = new Vector3(availableXPositions[Random.Range(0, availableXPositions.Length)], 0, currentSpawnPosition);
        if (lastXPos == spawnPosition.x)
        {
            samePosCount++;
        }
        else
        {
            samePosCount = 0;
        }
        if (samePosCount == maxSamePosCount)
        {
            var nextDiff = 0f;
            while (nextDiff != lastXPos)
            {
                nextDiff = availableXPositions[Random.Range(0, availableXPositions.Length)];
            }

            samePosCount = 0;
            spawnPosition.x = nextDiff;
        }
        var carObject = Instantiate(randomCar, spawnPosition, Quaternion.identity);
        if (carObject.transform.GetChild(0).name != "PoliceCar")
        {
            carObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = carColors[Random.Range(0, carColors.Length)];
        }
        carObject.transform.SetParent(carContainer.transform);
        currentSpawnPosition += spawnInterval;
        lastXPos = spawnPosition.x;
    }
}
