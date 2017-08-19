using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour 
{
	private GameObject wallPiece;

    private GameObject parent;
	private List<GameObject> wallTiles;
	private SpriteRenderer spriteRenderer;
    private float fireWidth, windowWidth, windowHeight, pixelsPerUnit;

	private ShowOutput output;
	private FetchTerminalInput input;

	private void Start()
	{
		wallPiece = Resources.Load<GameObject> (Paths.firewallPrefab);
		if (wallPiece == null)
			throw new System.Exception ("Failed to load wall resource!");
        
		spriteRenderer = wallPiece.GetComponent<SpriteRenderer> ();
		pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;
		fireWidth = spriteRenderer.sprite.texture.width;
		parent = null;

		output = FindObjectOfType<ShowOutput>();
		input = GetComponent<FetchTerminalInput> ();
		wallTiles = new List<GameObject> ();
	}

	public void create(GameObject parent, User server)
	{
		this.windowHeight = (Camera.main.orthographicSize * 2) * this.pixelsPerUnit;
		this.windowWidth = this.windowHeight * (float)16 / 9;
		this.parent = parent;

		var amountOfWalls = Mathf.Ceil(this.windowWidth/this.fireWidth); 
		for (int i = 0; i < amountOfWalls; i++)
		{
			var fireWall = Instantiate (wallPiece) as GameObject;
			fireWall.transform.SetParent (this.parent.transform);
			//calculation: (windowWidth/2)/-pixelsPerUnit 
			var xPos = -8.3889f + (i * (this.fireWidth / this.pixelsPerUnit));
			fireWall.transform.localPosition = new Vector3 (xPos, 8, 1);
			wallTiles.Add (fireWall);
		}
		StartCoroutine (waitForEnd(server));
		output.addText ("Successfully initialized attack.exe", false);
		return;
	}

	private IEnumerator waitForEnd(User check)
	{
		bool loop = true;
		while (loop)
		{
			if (wallTiles.Count == 0)
			{
				check.removeFirewall ();
				output.addText ("Removed firewall from: '"+check.Name+"' with ip: '"+check.IP+"'!", false);
				input.enableInput (true);
				loop = false;
				Destroy (this.parent);
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
