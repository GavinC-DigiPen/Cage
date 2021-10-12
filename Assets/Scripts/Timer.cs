//------------------------------------------------------------------------------
//
// File Name:	Timer.cs
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
using TMPro;

public class Timer : MonoBehaviour
{
    [Tooltip("Amount of time before the game ends in seconds")]
    public float time = 60;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Timer: " + time.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            time = 0;
            DestroyBalls();
        }
        else
        {
            time -= Time.deltaTime;
            GetComponent<TextMeshProUGUI>().text = "Timer: " + time.ToString("F1");
        }
    }

    // Function to destroy all balls
    void DestroyBalls()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        for (int i = 0; i <balls.Length; i++)
        {
            balls[i].DestroySelf();
        }
    }
}
