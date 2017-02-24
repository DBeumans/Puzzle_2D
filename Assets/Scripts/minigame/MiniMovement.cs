using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MiniMovement : MonoBehaviour
{
	private float speed;
	private Rigidbody2D rigid;
	private Vector2 movement;
	private Vector2 prevMovement;

	private void Start()
	{
		movement = Vector2.zero;
		prevMovement = Vector2.zero;
		speed = 5;
		rigid = GetComponent<Rigidbody2D> ();
	}

	private void Update()
	{
		var x = Input.GetAxisRaw ("Horizontal");
		var z = Input.GetAxisRaw ("Vertical");
		movement = new Vector2 (x,z);

		if (!(x == 0 && z == 0))
		{
			prevMovement = movement;
		}
	}

	private void FixedUpdate()
	{
		Vector2 velocity = movement.normalized * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + velocity);
	}
}
