using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour 
{
	[SerializeField]private GameObject wallPiece;
	[SerializeField]private Transform parent;
	[SerializeField]private Camera camera;
	private float fireWidth, windowWidth, windowHeight, pixelsPerUnit;
	private SpriteRenderer spriteRenderer;
	private void Start()
	{
		spriteRenderer = wallPiece.GetComponent<SpriteRenderer> ();
		pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;

		windowHeight = (camera.orthographicSize * 2) * pixelsPerUnit;
		windowWidth = windowHeight * (float)16 / 9;
		fireWidth = spriteRenderer.sprite.texture.width;

		var amountOfWalls = Mathf.Ceil(windowWidth/fireWidth); 
		for (int i = 0; i < amountOfWalls; i++)
		{
			GameObject fireWall = Instantiate (wallPiece) as GameObject;
			fireWall.transform.SetParent (parent);
			//first position should be: -8.3889f
			float xPos = (windowWidth/2)/-pixelsPerUnit + (i * (fireWidth / pixelsPerUnit));
			fireWall.transform.localPosition = new Vector3 (xPos, 8, 1);
		}
	}
}
