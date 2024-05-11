using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Define the rotation amount
    public float rotationAmount = 45f;
    public int objSelected = 0;

    //[SerializeField] SoundObjectController cube;
    [SerializeField] public SoundObjectController left;
    [SerializeField] public SoundObjectController mid;
    [SerializeField] public SoundObjectController right;

    // Update is called once per frame
    void Update()
    {
        // Check for left arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (objSelected != -1))
        {
            // Rotate the object to the left by the defined amount
            transform.Rotate(Vector3.up, -rotationAmount);
            StopObject();

            objSelected -= 1;
            PlayObject();
        }

        // Check for right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow) && (objSelected != 1))
        {
            // Rotate the object to the right by the defined amount
            transform.Rotate(Vector3.up, rotationAmount);
            StopObject();

            objSelected += 1;
            PlayObject();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //CHANGE THIS TO SELECT

            //PlayObject();
            SelectObject();


        }
    }


    public void PlayObject(){
        if (objSelected == -1){
            left.PlaySound();

        } else if (objSelected == 0){
            mid.PlaySound();
        }else { // == 1
            right.PlaySound();
        }
    }

    public void StopObject(){
        if (objSelected == -1){
            left.StopSound();

        } else if (objSelected == 0){
            mid.StopSound();
        }else { // == 1
            right.StopSound();
        }
    }

    public void SelectObject(){
        Debug.Log("this happend");

        if (objSelected == -1){
            left.SelectObject();

        } else if (objSelected == 0){
            mid.SelectObject();
        }else { // == 1
            right.SelectObject();
        }
    }


    public void ObjectsChange(int pos, SoundObjectController soundObjectController){
        Debug.Log("pizza even?");
        Debug.Log(pos);
        Debug.Log(soundObjectController);
        if (pos == 0){
            left = soundObjectController;
        } else if (pos == 1){
            mid = soundObjectController;
        } else{
            right = soundObjectController;
        }
    }
}
