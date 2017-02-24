using System.Collections;
using UnityEngine;

public class MouseInput : MonoBehaviour 
{
	private EditGrid edit;
	private void Start()
	{
		edit = GetComponent<EditGrid> ();
	}
	private void Update()
	{
		if (Input.GetMouseButtonDown (0))
		{
			edit.checkPosition (Camera.main.WorldToScreenPoint(Input.mousePosition));
		}
	}
}
