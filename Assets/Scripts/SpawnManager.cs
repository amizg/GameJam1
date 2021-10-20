using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;

    public float spawnLimitXLeft = -22;
    public float spawnLimitXRight = 7;
    public float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAsteroid", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnAsteroid()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], spawnPos, asteroidPrefabs[0].transform.rotation);

        spawnInterval = Random.Range(0.3f, 1.5f);
        Invoke("SpawnAsteroid", spawnInterval);
    }

}