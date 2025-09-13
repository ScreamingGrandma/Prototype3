using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerControllerScipt;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScipt = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle() 

    {
        if (playerControllerScipt.gameOver == false)
        {

            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
           
    }
}
