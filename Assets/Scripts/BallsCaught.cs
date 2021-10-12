//------------------------------------------------------------------------------
//
// File Name:	BallsCaught.cs
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

public class BallsCaught : MonoBehaviour
{
    int ballsCaught = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Balls Caught: " + ballsCaught.ToString();
    }

    // Increases the balls caught int and updates the text
    public void IncreaseBallsCaught()
    {
        ballsCaught++;
        GetComponent<TextMeshProUGUI>().text = "Balls Caught: " + ballsCaught.ToString();
    }
}
