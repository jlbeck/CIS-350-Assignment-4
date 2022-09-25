using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(35, 0, 0);

    private PlayerController playerControllerScript;

    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {

        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        
        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
