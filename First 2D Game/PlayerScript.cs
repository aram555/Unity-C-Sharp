using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float ApollonHP;
	public float speed;
	public float jumpSpeed;
	public float moveInput;
	private Rigidbody2D rb;
	public static bool Right = true;
	private Animator anim;
	public Joystick joystick;

	public Transform shotPoint;
	public GameObject Bullet;

	public GameObject Effect;
	public float Time = 0;
	public Transform WalkEffect;
	public GameObject ShotEffect;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void FixedUpdate() {
		moveInput = joystick.Horizontal;
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if(Right == false && moveInput > 0) {
			Flip();
		} else if(Right == true && moveInput < 0) {
			Flip();
		}

		if(moveInput == 0) {
			anim.SetBool("isRunning", false);
		} else {
			Time++;
			if (Time == 15)
			{
				Time = 0;
				Instantiate(Effect, WalkEffect.position, transform.rotation);
			}
			anim.SetBool("isRunning", true);
			
		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			Instantiate(Bullet, shotPoint.position, Quaternion.identity);
			Instantiate(ShotEffect, shotPoint.position, Quaternion.identity);
			anim.SetBool("Fire", true);
		} else
        {
			anim.SetBool("Fire", false);
		}
	}

	public void Jump() {
			rb.velocity = Vector2.up * jumpSpeed;
	}

	public void FireButton()
    {
		Instantiate(Bullet, shotPoint.position, Quaternion.identity);
		Instantiate(ShotEffect, shotPoint.position, Quaternion.identity);
		anim.SetBool("Fire", true);
	}

	void Flip() {
		Right = !Right;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	public void TakeDamage(int damage)
	{
		ApollonHP -= damage;
	}
}
