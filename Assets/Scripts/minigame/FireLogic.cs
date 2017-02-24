using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour 
{
	private float speed;
	private Transform player;
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag ("MiniPlayer").transform;
		speed = 0.8f;
	}
	private void Update()
	{
		this.transform.Translate (Vector3.down * speed * Time.deltaTime);
		if (this.transform.position.y < player.transform.position.y)
		{
			Destroy (player.gameObject);
			this.enabled = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name != this.name)
		{
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
