using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalsPrefabs;
    float spawnPosX = 15f;
    float spawnPosZ = 15f;
    float startDelay = 2f;
    float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimals()
    {
        int animalsIndex = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnPositions = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ);
        Instantiate(animalsPrefabs[animalsIndex], spawnPositions, animalsPrefabs[animalsIndex].transform.rotation);
    }
}
