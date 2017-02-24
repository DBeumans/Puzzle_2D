using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MiniMovement : MonoBehaviour
{
	private float speed;
	private Rigidbody2D rigid;
	private Vector2 movement;
	private Vector3 playerSize;
	private CameraBorders borders;

	private void Start()
	{
		movement = Vector2.zero;
		speed = 8;
		rigid = GetComponent<Rigidbody2D> ();
		playerSize = GetComponent<Renderer> ().bounds.size;
		borders = new CameraBorders ();
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
		this.transform.position = new Vector3 (Mathf.Clamp(this.transform.position.x, borders.getLeftBorder(dist) + playerSize.x/2, borders.getRightBorder(dist) - playerSize.x/2), Mathf.Clamp(this.transform.position.y, borders.getTopBorder(dist) + playerSize.y/2, borders.getBottomBorder(dist) - 1 - playerSize.y/2), this.transform.position.z);

	}
}
