using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public int HP;

    public Transform Player;
    public Rigidbody2D rb;
    public GameObject Bullet;

    private float timeBtwShot;
    public float StartTimeBtwShot;
    public GameObject EnemyBullet;
    public Transform ShotPoint;

    private Transform player;
    private Vector2 target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeBtwShot = StartTimeBtwShot;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        if(timeBtwShot <= 0)
        {
            Instantiate(EnemyBullet, ShotPoint.position, transform.rotation);
            timeBtwShot = StartTimeBtwShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            HP -= 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "HPBox")
        {
            HP += 10;
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "JumpBox")
        {
            Destroy(collision.gameObject);
        }
    }
}
