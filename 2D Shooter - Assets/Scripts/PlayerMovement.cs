using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int HP;
    public int speed;
    public int jumpForce;
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public bool isJumping;
    public GameObject JumpPartycle;
    public Transform ParticleSpawn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isJumping == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
            Instantiate(JumpPartycle, ParticleSpawn.position, transform.rotation);
        }

        if(HP <= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            HP -= 10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Border")
        {
            isJumping = true;
        }
        if(collision.collider.tag == "HPBox")
        {
            HP += 20;
            Destroy(collision.gameObject);
        }
        if(collision.collider.tag == "JumpBox")
        {
            jumpForce += 2;
            Destroy(collision.gameObject);
        }
    }
}
