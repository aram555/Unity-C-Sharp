using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudaSuda : MonoBehaviour
{
    public float dirX1;
    public float dirX2;
    public float speed;
    public bool movingRight = true;
    
    void Update()
    {
        if(transform.position.x > dirX1)
        {
            movingRight = false;
        }
        if (transform.position.x < dirX2)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        } else if(movingRight == false)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
