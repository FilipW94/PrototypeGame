using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    private enum State
    {
        Red,
        Green,
        Blue
    }

    private State currentState = State.Red;
    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    private void Update()
    {
        // Check for user input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = State.Red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = State.Green;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = State.Blue;
        }

        // Update the color based on the current state
        UpdateColor();
    }

    private void UpdateColor()
    {
        // Change the color of the GameObject based on the current state
        Color newColor = Color.white;

        switch (currentState)
        {
            case State.Red:
                newColor = Color.red;
                break;
            case State.Green:
                newColor = Color.green;
                break;
            case State.Blue:
                newColor = Color.blue;
                break;
        }

        objectRenderer.material.color = newColor;
    }
}
