using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCollectablePosition : MonoBehaviour
{
    private GameObject col;

    // Start is called before the first frame update
    void Start()
    {
        col = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z);
    }
}
