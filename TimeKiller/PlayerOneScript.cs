using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    public float speed;
    private Vector3 moveInput;
    Rigidbody rb;
    FallZone fal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fal = new FallZone();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            rb.velocity += new Vector3(0, 0, speed * Time.deltaTime); 
        }
        if(Input.GetKey(KeyCode.S)) {
            rb.velocity += new Vector3(0, 0, -speed * Time.deltaTime); 
        }
        if(Input.GetKey(KeyCode.A)) {
            rb.velocity += new Vector3(-speed * Time.deltaTime, 0, 0); 
        }
        if(Input.GetKey(KeyCode.D)) {
            rb.velocity += new Vector3(speed * Time.deltaTime, 0, 0); 
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Street") {
            fal.fall = false;
        }
    }
}
