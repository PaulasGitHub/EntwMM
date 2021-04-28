using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    float speed = 3.0f; //movement spped for monster
    private Rigidbody monsterRB;
    private GameObject player;

    float xBorder = 6;  //range for monster movement in x-direction
    float zBorder = 6;  //range for monster movement in z-direction

    // Start is called before the first frame update
    void Start()
    {
        monsterRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //get position of player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //add force to RigidBody of monster in direction of player
        //monster moves speed fast towards player position
        monsterRB.AddForce(lookDirection * speed);

        keepMonsterInbounds();
    }

    //stops the monster from moving off the playing field
    void keepMonsterInbounds()
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
}
