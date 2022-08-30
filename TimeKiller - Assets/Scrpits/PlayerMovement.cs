using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int normalSpeed;
    public Rigidbody rb;
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        normalSpeed = PlayerPrefs.GetInt("Speed") + 5;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
    }

    public void LeftButton()
    {
        if(speed >= 0)
        {
            speed = -normalSpeed;
        }
    }

    public void RightButton()
    {
        if (speed >= 0)
        {
            speed = normalSpeed;
        }
    }

    public void onButtonUp()
    {
        speed = 0;
    }
}
