using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour
{
    public GameObject player;
    float moveSpeed = 1.0f;
    float rotateSpeed = 10.0f;
    private bool left, right, forward, rotate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        left = false;
        right = false;
        forward = false;
        rotate = false;

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; i++)
        {
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbs[i].RegisterOnButtonReleased(OnButtonReleased);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            player.transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;
        }

        else if (right)
        {
            player.transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;
        }

        else if (forward)
        {
            player.transform.localPosition += Vector3.forward * -moveSpeed * Time.deltaTime;
        }

        else if (rotate)
        {
            Quaternion oldRotation = player.transform.localRotation;
            player.transform.localRotation = Quaternion.AngleAxis(rotateSpeed, Vector3.up) * oldRotation;
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "left":
                Debug.Log("left button pressed");
                left = true;
                break;

            case "right":
                Debug.Log("right button pressed");
                right = true;
                break;

            case "forward":
                Debug.Log("forward button pressed");
                forward = true;
                break;

            case "rotate":
                Debug.Log("rotate button pressed");
                rotate = true;
                break;

            default: break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "left":
                Debug.Log("left button released");
                left = false;
                break;

            case "right":
                Debug.Log("right button released");
                right = false;
                break;

            case "forward":
                Debug.Log("forward button released");
                forward = false;
                break;

            case "rotate":
                Debug.Log("rotate button released");
                rotate = false;
                break;

            default:
                break;
        }
    }
}
