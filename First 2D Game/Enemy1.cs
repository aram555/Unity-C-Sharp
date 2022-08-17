using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int HP;
    public float speed;
    public float StopDistance;
    public float RetreatDistance;

    public GameObject Bullet;
    public Transform ShotPoint;

    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            MoneyScript.Coins++;
        }

        if(Vector2.Distance(transform.position, Player.position) > StopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, Player.position) < StopDistance && Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
        } else if(Vector2.Distance(transform.position, Player.position) < RetreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
