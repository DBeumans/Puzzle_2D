using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSelect : MonoBehaviour {

	[SerializeField]private Vector3 lastPos;

	public Vector3 GetLastPos{get{return lastPos; } }

    private bool buttonSelected;
    public bool GetButtonSelected { get { return buttonSelected; } }

	Editor_ObjectMouseFollower objectMouseFollower;

	private void Start()
	{
		objectMouseFollower = GetComponent<Editor_ObjectMouseFollower> ();
	}
	public void selectObject()
	{
		lastPos = this.transform.position; // saving the last position.
        buttonSelected = true;
		objectMouseFollower.GetFoll=true;

	}
    public void deselectObject()
    {
        transform.position = lastPos;
        buttonSelected = false;
        objectMouseFollower.GetFoll = false;
    }
    public void placeObject(Vector2 postion)
    {
        lastPos = postion;
        print(lastPos);
        buttonSelected = false;
        objectMouseFollower.GetFoll = false;
    }
}
