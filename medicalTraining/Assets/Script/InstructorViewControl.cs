using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructorViewControl : MonoBehaviour
{
    public float xSpeed = 2f; //Speed of rotating camera on left and right
    public float ySpeed = 2f; //Speed of rotating camera on up and down
    public float yMinLimit = -90f; //Minimum roteting angle y axis
    public float yMaxLimit = 90f;  //Miximum roteting angle y axis


    //if mouse right button down then is true
    private bool isRotate;
    //Rotating angle for world (y axis)
    private float x;
    //Rotating angle for world (x axis)
    private float y;



    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        //Mouse moving on left and right (moving on Y axis)
        x = angles.y;
        //Mouse moving on up and down (moving on X axis)
        y = angles.x;
    }


    void Update()
    {
        RotateCamera();
    }


    void RotateCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }

        if (isRotate)
        {

            //When mouse moving up and down, Mouse Y equals moving on X axis in 3D
            y -= Input.GetAxis("Mouse Y") * ySpeed;
        
            //Set limitation for rotation angle, otherwise the camera will be upside down
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);


            //When mouse moving left and right, Mouse X equals moving on Y axis in 3D
            x += Input.GetAxis("Mouse X") * xSpeed;

            //Quaternion rotation = Quaternion.Euler(y, x, 0);
            //transform.rotation = rotation;

            //equals to above 2 lines
            transform.eulerAngles = new Vector3(y, x, 0);

        }
    }

}
