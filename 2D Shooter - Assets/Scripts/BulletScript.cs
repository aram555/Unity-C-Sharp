using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public int HP;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("EnemyBullet"))
        {
            HP -= 10;
        }
    }
}
