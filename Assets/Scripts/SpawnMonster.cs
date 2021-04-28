using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monster;
    private float spawnPosX = 5;    //range for random x-Position
    private float spawnPosY = 1;    //y-Position
    private float spawnPosZ = 5;    //range for random z-Position

    [SerializeField, Range(0, 3)]
    int monsterCounter = 3;

    [SerializeField, Range (0, 5)]
    private float minDistance = 5; //minimum distance between spawned objects

    // Start is called before the first frame update
    void Start()
    {
        MakeMonster(); //create the Monster      
    }

    void Update()
    {
        
    }

    /**
     * create monsterCounter many Monster at minDistance distance from each other
     * creates array to store positions
     * goes through array and:
     *  creates new random position
     *  checks if distance between positions in array and new position is bigger than minDistance
     *      if yes: new position goes into array
     *      if no: repeat
     * after whole array is checked and "clear": instantiate monster
     * */
    void MakeMonster()
    {
        bool posFree;
        Vector3[] allPos = new Vector3[monsterCounter]; 
        for (int j = 0; j < allPos.Length; j++)
        {
            do
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, Random.Range(-spawnPosZ, spawnPosZ));
                posFree = true;

                for (int i = 0; i < allPos.Length; i++) 
                {
                    if (Mathf.Abs(allPos[i].x - spawnPos.x) < minDistance && Mathf.Abs(allPos[i].z - spawnPos.z) < minDistance)
                    {
                        posFree = false;
                    }
                    else
                    {
                        allPos[i] = spawnPos;
                    }
                }
            } while (!posFree);
            Instantiate(monster, allPos[j], monster.transform.rotation);
        }
    }
}
