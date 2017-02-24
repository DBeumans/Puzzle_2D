using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	private float speed;
	private float dist;
	private CameraBorders borders;

	private void Start()
	{
		borders = new CameraBorders ();
	}

	private void Update () 
	{
		transform.Translate (Vector3.up * speed * Time.deltaTime);

		var camY = Camera.main.ViewportToWorldPoint(this.transform.position).y;
		if (camY > 36)
		{
			Destroy (this.gameObject);
		}
	}

	public void setSpeed(float value)
	{
		speed = value;
	}
}
