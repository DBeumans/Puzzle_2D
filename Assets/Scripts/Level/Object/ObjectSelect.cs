using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSelect : MonoBehaviour {

	[SerializeField]private Vector3 lastPos;

	public Vector3 GetLastPos{get{return lastPos; } }

	Editor_ObjectMouseFollower objectMouseFollower;

	private void Start()
	{
		objectMouseFollower = GetComponent<Editor_ObjectMouseFollower> ();
	}
	public void selectObject()
	{
		lastPos = this.transform.position; // saving the last position.
		objectMouseFollower.GetFoll=true;

	}
}
