using System.Collections;
using UnityEngine;

public class CreateGrid : MonoBehaviour 
{
	private Grid grid;
	public Grid TheGrid
	{
		get{return grid;}
	}
	private Vector2[] walls; 
	private int width, height;
    [SerializeField]private GameObject myParent;

	private void Start()
	{
		walls = new Vector2[3];
		width = height = 20;
		grid = new Grid (width,height);

        

		walls[0] = new Vector2(3,3);
		walls [1] = new Vector2 (6,13);
		walls [2] = new Vector2 (1,18);
		setWalls ();
		checkGrid ();
	}

	private void setWalls()
	{
		for(int i=0; i<walls.Length;i++)
		{
			grid.GetNode (walls[i]).IsWalkable = false;
		}
	}

	private void checkGrid()
	{
		for (int x = 0; x < grid.Width; x++)
		{
			for (int y = 0; y < grid.Height; y++)
			{
				if (!grid.GetNode (x, y).IsWalkable)
				{
					continue;
				}

				createPlane (x,y);
			}
		}
	}

	private void createPlane(int x, int y)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
        cube.transform.position = new Vector2 (x , y);
        cube.transform.SetParent(myParent.transform);
    }
}
