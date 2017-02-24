using System.Collections;
using UnityEngine;

public class EditGrid : MonoBehaviour 
{
	private CreateGrid grid;

	private void Start()
	{
		grid = GetComponent<CreateGrid> ();
	}

	public void checkPosition(Vector2 position)
	{
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition),transform.forward*100, out hit))
		{
			Debug.DrawLine (Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward * 100, Color.red);
			if (grid.TheGrid.IsOnGrid ((int)hit.collider.transform.position.x,(int)hit.collider.transform.position.y))
			{

				print ("onGrid");
			} 
			else
			{
				print ("Not on grid");
			}
		}
	}
}
