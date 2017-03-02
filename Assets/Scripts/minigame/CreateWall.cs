  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour 
{
	private GameObject wallPiece;

	private List<GameObject> wallTiles;
	private float fireWidth, windowWidth, windowHeight, pixelsPerUnit;
	private SpriteRenderer spriteRenderer;
	private GameObject parent;
	private ShowOutput output;
	private IEnumerator check = null;
	private FetchTerminalInput input;
	private void Start()
	{
		wallPiece = Resources.Load<GameObject> (Paths.firewallPrefab);
		if (wallPiece == null)
		{
			throw new System.Exception ("Failed to load wall resource!");
		}
		output = FindObjectOfType<ShowOutput>();
		input = GetComponent<FetchTerminalInput> ();
		wallTiles = new List<GameObject> ();
	}

	public string createWall(GameObject parent, string ip)
	{
		this.parent = parent;
		spriteRenderer = wallPiece.GetComponent<SpriteRenderer> ();
		pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;

		windowHeight = (Camera.main.orthographicSize * 2) * pixelsPerUnit;
		windowWidth = windowHeight * (float)16 / 9;
		fireWidth = spriteRenderer.sprite.texture.width;

		var amountOfWalls = Mathf.Ceil(windowWidth/fireWidth); 
		for (int i = 0; i < amountOfWalls; i++)
		{
			GameObject fireWall = Instantiate (wallPiece) as GameObject;
			fireWall.transform.SetParent (parent.transform);
			//calculation: (windowWidth/2)/-pixelsPerUnit 
			float xPos = -8.3889f + (i * (fireWidth / pixelsPerUnit));
			fireWall.transform.localPosition = new Vector3 (xPos, 8, 1);
			fireWall.GetComponent<FireLogic>().initialize ();
			wallTiles.Add (fireWall);
		}
		check = waitForEnd (ip);
		StartCoroutine (check);
		return "Successfully initialized attack.exe";
	}

	private IEnumerator waitForEnd(string ip)
	{
		bool loop = true;
		while (loop)
		{
			if (wallTiles.Count == 0)
			{
				output.addText(ConnectToComputer.connectToUser (ip, true), false);
				input.enableInput (true);
				StopCoroutine (check);
				Destroy (parent);
			}
			yield return new WaitForSeconds (1);
		}
	}


	public void removeTile(GameObject tile)
	{
		wallTiles.Remove (tile);
		Destroy (tile);
	}
}
