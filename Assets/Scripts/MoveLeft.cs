using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private float leftBound = 15f;

    private PlayerController playerControllerScipt;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScipt = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScipt.gameOver == false)
        {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        if (transform.position.x < -leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
