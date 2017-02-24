using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MiniMovement : MonoBehaviour
{
	private float speed;
	private Rigidbody2D rigid;
	private Vector2 movement;
	private Renderer playerRenderer;

	private void Start()
	{
		movement = Vector2.zero;
		speed = 6;
		rigid = GetComponent<Rigidbody2D> ();
		playerRenderer = GetComponent<Renderer> ();
	}

	private void Update()
	{
		var x = Input.GetAxisRaw ("Horizontal");
		var z = Input.GetAxisRaw ("Vertical");
		movement = new Vector2 (x,z);
	}

	private void FixedUpdate()
	{
		Vector2 velocity = movement.normalized * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + velocity);

		var dist = (this.transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,dist)).y;

		Vector3 playerSize = playerRenderer.bounds.size;

		this.transform.position = new Vector3 (
			Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x/2, rightBorder - playerSize.x/2),
			Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y/2, bottomBorder - 1 - playerSize.y/2),
			this.transform.position.z
		);

	}
}
