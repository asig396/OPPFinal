using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    private float spawnRangeX = 45;
    private float spawnPosZ = 120;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnRandomShips", spawnDelay, spawnInterval);
    }
    void SpawnRandomShips()
    {
        int enemyIndex = Random.Range(0, enemiesPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(enemiesPrefabs[enemyIndex], spawnPos, enemiesPrefabs[enemyIndex].transform.rotation);
    }
}
