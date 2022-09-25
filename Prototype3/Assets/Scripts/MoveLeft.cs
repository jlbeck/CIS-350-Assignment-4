﻿/*
 * Josh Beck
 * Prototype 3
 * Controls movement of obstacles and background
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 30f;
    private float leftBound = -15;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {

        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            //if we are out of bounds to the left and the gameObject is an obstacle, destroy this GameObject
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }

       
    }
}
