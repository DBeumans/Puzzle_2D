using UnityEngine;
using System;

public class MiniShooting : MonoBehaviour 
{
	[SerializeField]private Projectile projectilePrefab;
	[SerializeField]private Transform muzzle;
	private int bulletSpeed;
	private float waitTime;
	private float fireRate;

	private void Start()
	{
		bulletSpeed = 8;
		fireRate = 0.4f;
		waitTime = 0;
	}
	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && Time.time >= waitTime)
		{
			shoot ();
		}
	}

	private void shoot()
	{
		Projectile newProjectile = Instantiate (projectilePrefab, muzzle.position, Quaternion.identity) as Projectile;
		newProjectile.transform.SetParent (Camera.main.transform);
		newProjectile.setSpeed (bulletSpeed);
		waitTime = Time.time + fireRate;
	}
}
