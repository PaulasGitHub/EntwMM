using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //variables to count collectable/monster encounters
    float score;
    float collectableCounter = 0;
    float monsterCounter = 0;

    //variables for movement
    private float moveHorizontal;
    private float moveVertical;

    private float xBorder = 5f;     //range for player movement in x-direction
    private float zBorder = 5f;     //range for player movement in z-direction

    private float speed = 5.0f;

    float angle = 0;

     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        //calculate rotation angle
        angle += moveHorizontal * 0.01f * Time.deltaTime;
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotationR = Quaternion.LookRotation(targetDirection);

        //move Player left, right, forwards, backwards
        Vector3 targetForward = rotationR * Vector3.forward;
        Vector3 targetRight = rotationR * Vector3.right;

        //move player according to ratation
        transform.Translate(targetForward * Time.deltaTime * speed * moveVertical);
        transform.Translate(targetRight * Time.deltaTime * speed * moveHorizontal);

        //rotate Player clockwise when e is pressed
        if (Input.GetKey(KeyCode.E))
        {
            transform.rotation *= Quaternion.Euler(0, 1, 0);
        }

        //rotate Player anti-clockwise when q is pressed
        if (Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= Quaternion.Euler(0, -1, 0);
        }

        keepPlayerInbounds();
        
    }

    //stops the Player from moving off the playing field
    void keepPlayerInbounds()
    {
        if (transform.position.x < -xBorder)
        {
            transform.position = new Vector3(-xBorder, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBorder)
        {
            transform.position = new Vector3(xBorder, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBorder);
        }

        if (transform.position.z > zBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBorder);
        }
    }

    /**
     * checks for collisions with other game objects and prints them to the console
     * if collectable:
     *  score goes up one point
     *  collectable is destroyed
     *  collectablecounter goes up one
     * if monster:
     *  score goes down one point
     *  monstercounter goes up one point
     * */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            score++;
            collectableCounter++;
            Debug.Log("The Score is: " + score + " You have collected " + collectableCounter + " Hearts" +
                " and survived a Monster " + monsterCounter + " times");
        }

        if (other.CompareTag("Monster"))
        {
            score--;
            monsterCounter++;
            Debug.Log("The Score is: " + score + " You have collected " + collectableCounter + " Hearts" +
               " and survived a Monster " + monsterCounter + " times");
        }
    }
}
