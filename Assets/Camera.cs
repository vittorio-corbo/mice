using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Define the rotation amount
    public float rotationAmount = 45f;

    // Update is called once per frame
    void Update()
    {
        // Check for left arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Rotate the object to the left by the defined amount
            transform.Rotate(Vector3.up, -rotationAmount);
        }

        // Check for right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Rotate the object to the right by the defined amount
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}
