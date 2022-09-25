using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {

        //save starting position of the background
        startPosition = transform.position;

        //set repeatWidth to half of the width of the background using the BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {

        //if background is further to left than repeatWidth, reset it to the starting position
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }

    }
}
