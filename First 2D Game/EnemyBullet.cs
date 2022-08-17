using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	private float speed = 15f;
	private int damage = 5;
	private int life = 0;
	private int lifeMax = 300;

	private bool Right;
	public LayerMask Solid;

	void Start()
	{
		Right = PlayerScript.Right;
	}

	void Update()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, Solid);
		if (hitInfo.collider != null)
		{
			if (hitInfo.collider.CompareTag("Apollon"))
			{
				hitInfo.collider.GetComponent<Enemy1>().TakeDamage(damage);
			}
		}

		life++;
		if (life >= lifeMax)
		{
			Destroy(gameObject);
		}

		if (!Right)
		{
			transform.Translate(-Vector2.right * speed * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
	}
}
