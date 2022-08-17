using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudaSuda : MonoBehaviour
{
    public float dirX1;
    public float dirX2;
    public float speed;
    public bool movingRight = true;
    public float timer;
    public float newtimer;
    
    void Update()
    {
        if(transform.position.z >= dirX1)
        {
            movingRight = false;
        }
        if (transform.position.z <= dirX2)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                timer += Time.deltaTime;
            }
        } 
        else if(movingRight == false)
        {
            timer += Time.deltaTime;
            if(timer >= newtimer) {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                timer -= Time.deltaTime;
            }
        }
    }
}
