using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed;

    public Rigidbody rb;
    public Animator anim;

    public float Jump;
    public bool doJump;
    public bool isGround = true;

    public GameObject RunEffect;
    public GameObject JumpEffect;
    public Transform EffectPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGround)
        {
            Instantiate(RunEffect, EffectPoint.position, transform.rotation);
        }

        if (Input.GetKeyDown("space") && isGround == true)
        {
            JumpVoid();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);

        if (doJump)
        {
            rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);
            anim.Play("AnimationForPlayer");

            doJump = false;
            isGround = false;
        }
        else if(isGround)
        {
            anim.Play("Idle");
        }
    }

    public void JumpVoid()
    {
        doJump = true;
        isGround = false;
        Instantiate(JumpEffect, EffectPoint.position, transform.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }

        if (collision.collider.tag == "Ground")
        {
            isGround = true;
        }
    }
}
