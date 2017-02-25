using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	private float speed;
	private float dist;

	private void Update () 
	{
		transform.Translate (Vector3.up * speed * Time.deltaTime);

		var camY = Camera.main.ViewportToWorldPoint(this.transform.localPosition).y;
		if (camY > 45)
		{
			Destroy (this.gameObject);
		}
	}

	public void setSpeed(float value)
	{
		speed = value;
	}
}
