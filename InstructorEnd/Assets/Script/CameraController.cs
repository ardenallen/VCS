using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject cam;

    public float xMax = -0.65f; //Maximum x axis
    public float xMin = -5.579f; //Minimum x axis
    public float zMax = 4.54f; //Maximum z axis
    public float zMin = -1.35f; //Minimum z axis

    public float xSpeed = 2f; //Speed of rotating camera on left and right
    public float ySpeed = 2f; //Speed of rotating camera on up and down
    public float yMinLimit = -90f; //Minimum roteting angle y axis
    public float yMaxLimit = 90f;  //Miximum roteting angle y axis

    public float scaleSpeed = 5f;
    public float distance = 5f;
    public float maxDistance = 10f;
    public float minDistance = 5f;

    //if mouse right button down then is true
    private bool isRotate;
    //Rotating angle for world (y axis)
    private float x;
    //Rotating angle for world (x axis)
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = cam.transform.eulerAngles;
        //Mouse moving on left and right (moving on Y axis)
        x = angles.y;
        //Mouse moving on up and down (moving on X axis)
        y = angles.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {     
         MoveCharacter();
         RotateCamera();
    }


    void MoveCharacter()
    {
        float xm = 0, ym = 0, zm = 0;

        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            xm -= moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            xm += moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            zm += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            zm -= moveSpeed * Time.deltaTime;
        }

        transform.Translate(new Vector3(xm, ym, zm), Space.Self);

        
        if (transform.position.x <= xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }

        if (transform.position.z <= zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }
        else if (transform.position.z >= zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }
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
            //cam.transform.rotation = rotation;

            //equals to above 2 lines
            cam.transform.eulerAngles = new Vector3(y, x, 0);


            Vector3 camrot = cam.transform.eulerAngles;
            camrot.x = 0;
            camrot.z = 0;
            transform.eulerAngles = camrot;
        }

    }

    //void ZoomCamera()
    //{
    //    distance -= Input.GetAxis("Mouse ScrollWheel") * scaleSpeed;
    //    distance = Mathf.Clamp(distance, minDistance, maxDistance);

    //    //重新计算位置  
    //    Vector3 mPosition = mRotation * new Vector3(0.0F, 0.0F, -Distance) + Target.position;

    //    //设置相机的位置  
    //    if (isNeedDamping)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping);
    //    }
    //    else
    //    {
    //        transform.position = mPosition;
    //    }

    //}
}
 