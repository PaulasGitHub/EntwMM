using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float x = 0.5f;    //camera offset in x-direction
    float y = -0.5f;   //camera offset in y-direction
    float z = 5.4f;    //camera offset in z-direction

    Vector3 offset;     //offset - distance between camera and player

    public Transform target; //linking main camera with player-object

    void Start()
    {
         
    }


    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(x, y, z);

        //rotating offset vector, so that camera also follows player's rotation
        Vector3 offsetRotated = target.rotation * offset;
        transform.rotation = target.rotation;
        transform.position = target.transform.position - offsetRotated;
    }
}
