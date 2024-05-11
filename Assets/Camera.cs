using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Define the rotation amount
    public float rotationAmount = 45f;
    public int objSelected = 0;

    [SerializeField] SoundObjectController cube;

    // Update is called once per frame
    void Update()
    {
        // Check for left arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (objSelected != -1))
        {
            // Rotate the object to the left by the defined amount
            transform.Rotate(Vector3.up, -rotationAmount);

            objSelected -= 1;
        }

        // Check for right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow) && (objSelected != 1))
        {
            // Rotate the object to the right by the defined amount
            transform.Rotate(Vector3.up, rotationAmount);

            objSelected += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cube.PlaySound();
        }
    }
}
