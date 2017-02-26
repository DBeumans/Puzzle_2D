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

		var dist = (this.transform.localPosition - Camera.main.transform.position).z;
		if (this.transform.localPosition.y > borders.getBottomBorder(dist, 1.5f))
		{
			Destroy (this.gameObject);
		}
	}

	public void setSpeed(float value)
	{
		speed = value;
	}
}
