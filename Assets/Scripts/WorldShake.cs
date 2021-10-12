//------------------------------------------------------------------------------
//
// File Name:	WorldShake.cs
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

public class WorldShake : MonoBehaviour
{
    [Tooltip("The range of the starting velocity of the ball")]
    public Vector2 shakeVelocityRange = new Vector2(-500, 500);
    [Tooltip("Do you want the screen to shake when the world shakes")]

    public bool screenShake = true;
    [Tooltip("The range of duration of the screen shake")]
    public Vector2 shakeScreenDurationRange = new Vector2(1, 3);
    [Tooltip("The range of magnitude of the screen shake")]
    public Vector2 shakeScreenMagnitudeRange = new Vector2(20, 25);

    Vector3 startingPosition;
    float duration = 0;
    float magnitude = 20;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shake();
        }

        if (screenShake)
        {
            if (duration > 0)
            {
                transform.position += (Vector3)Random.insideUnitCircle * magnitude * Time.deltaTime;

                duration -= Time.deltaTime;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, startingPosition, 0.5f);
            }
        }
    }

    // Function to shake the balls
    void Shake()
    {
        // Move balls
        Vector2 shakeVelocity;
        shakeVelocity.x = Random.Range(shakeVelocityRange.x, shakeVelocityRange.y);
        shakeVelocity.y = Random.Range(shakeVelocityRange.x, shakeVelocityRange.y);

        Ball[] balls = FindObjectsOfType<Ball>();
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<Rigidbody2D>().AddForce(shakeVelocity);
        }

        // Shake screen
        if (screenShake)
        {
            if (duration <= 0)
            {
                duration = Random.Range(shakeScreenDurationRange.x, shakeScreenDurationRange.y);
                magnitude = Random.Range(shakeScreenMagnitudeRange.x, shakeScreenMagnitudeRange.y);
            }
        }
    }
}
