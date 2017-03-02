using UnityEngine;

public class ObjectSelect : MonoBehaviour {

	[SerializeField]private Vector3 lastPos;

	public Vector3 GetLastPos{get{return lastPos; } }

    private bool buttonSelected;
    public bool GetButtonSelected { get { return buttonSelected; } }

    private string objName;
    public string GetObjectName { get { return objName; } set { objName = value; } }

	private Editor_ObjectMouseFollower objectMouseFollower;
    private ObjectTriggerCollision objectCollision;

	private void Start()
	{
		objectMouseFollower = GetComponent<Editor_ObjectMouseFollower> ();
        objectCollision = GetComponent<ObjectTriggerCollision>();
        objName = this.transform.gameObject.name;
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
        if (!objectCollision.GetCanPlaceObject)
            return;
        else
        {
            lastPos = postion;
            transform.gameObject.name = objName;
            buttonSelected = false;
            objectMouseFollower.GetFoll = false;
            print("LOL");
        }
        
    }
}
