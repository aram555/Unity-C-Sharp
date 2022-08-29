using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudaSudaVertical : MonoBehaviour
{

    public float dirZ1;
    public float dirZ2;
    public float speed;
    public bool movingVertical = true;

    void Update()
    {
        if (transform.position.z > dirZ1)
        {
            movingVertical = false;
        }
        if (transform.position.z < dirZ2)
        {
            movingVertical = true;
        }

        if (movingVertical)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
        else if (movingVertical == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }
    }
}
