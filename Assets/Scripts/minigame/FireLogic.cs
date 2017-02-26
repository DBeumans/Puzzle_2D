using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour 
{
	private float speed;
	private Transform player;
	private CreateWall wall;

	public void initialize()
	{
		player = GameObject.FindGameObjectWithTag ("MiniPlayer").transform;
		wall = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CreateWall>();;
		speed = 0.8f;
	}
	private void Update()
	{
		this.transform.Translate (Vector3.down * speed * Time.deltaTime);
		if (this.transform.position.y < player.transform.position.y)
		{
			Destroy (this.transform.parent.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name != this.name)
		{
			Destroy (other.gameObject);
			wall.removeTile (this.gameObject);
		}
	}
}
