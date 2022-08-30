using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousScript : MonoBehaviour
{
    [Header("Moving")]
    public float dirXplus;
    public float dirXminus;
    public float speed;
    public bool movingRight;
    public bool isMoving;
    [Header("Rotation")]
    public float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotationspeed != 0) transform.Rotate(0, 0, rotationspeed * Time.deltaTime);

        if(isMoving) {
            if(transform.position.x > dirXplus) movingRight = false;
            else if(transform.position.x < dirXminus) movingRight = true;
    
            if(movingRight) transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            else transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
