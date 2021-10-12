//------------------------------------------------------------------------------
//
// File Name:	Ball.cs
// Author(s):	Gavin Cooper (gavin.cooper@digipen.edu)
// Project:	    Cage
// Course:	    WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Tooltip("The starting velocity of the ball")]
    public Vector2 startingVelocityRange = new Vector2(-500, 500);

    // Start is called before the first frame update
    void Start()
    {
        Vector2 startingVelocity;
        startingVelocity.x = Random.Range(startingVelocityRange.x, startingVelocityRange.y);
        startingVelocity.y = Random.Range(startingVelocityRange.x, startingVelocityRange.y);

        GetComponent<Rigidbody2D>().AddForce(startingVelocity);   
    }

    // Check if collide with a trigger and destroy self
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<BallsCaught>().IncreaseBallsCaught();
        Destroy(gameObject);
    }

    // Function to be called that destroys the ball
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
