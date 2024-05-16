using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerr : MonoBehaviour
{
    [SerializeField] GameObject obsPrefab;
    Vector3 spawnObstaclesPosition=new Vector3(20,0,0);
    float startDelay=1f;
    float spawnInterval=2f;
    private Player3 playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript =GameObject.Find("Player").GetComponent<Player3>();
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(obsPrefab, spawnObstaclesPosition, obsPrefab.transform.rotation);
        }
        
    }
}
