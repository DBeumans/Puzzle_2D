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
		this.transform.localPosition = new Vector3 (0,-4,1);
	}

	private void Update()
	{
		var x = Input.GetAxisRaw ("Horizontal");
		var y = Input.GetAxisRaw ("Vertical");
		movement = new Vector2 (x,y);

		var dist = (this.transform.localPosition - Camera.main.transform.position).z;
		this.transform.localPosition = new Vector3 (Mathf.Clamp(this.transform.localPosition.x, borders.getLeftBorder(dist, this.transform.parent.position.x), borders.getRightBorder(dist, this.transform.parent.position.x)), Mathf.Clamp(this.transform.localPosition.y, borders.getTopBorder(dist), borders.getBottomBorder(dist, playerSize.y/2 +1)), this.transform.localPosition.z);
	}

	private void FixedUpdate()
	{
		Vector2 velocity = movement.normalized * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + velocity);
	}
}
