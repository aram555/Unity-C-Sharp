using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public float X1;
    public float X2;
    public bool MovingRight = true;
    public Rigidbody rb;
    private void FixedUpdate()
    {
        if(transform.position.x <= X1)
        {
            MovingRight = true;
        }
        else if(transform.position.x >= X2)
        {
            MovingRight = false;
        }
        
        if(MovingRight)
        {
            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + -Vector3.right * speed * Time.deltaTime);
        }
    }
}
