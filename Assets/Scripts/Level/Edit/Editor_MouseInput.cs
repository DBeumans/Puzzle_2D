using UnityEngine;
using UnityEngine.EventSystems;

public class Editor_MouseInput : MonoBehaviour {

	private InputBehaviour input;
	private Editor_SpawnObject editorObjectSpawner;
    private ObjectSelect objSelector; // a variable to store the hit.getcomponent...

	void Start () 
	{
		input = GetComponent<InputBehaviour> ();	
		editorObjectSpawner = GetComponent<Editor_SpawnObject> (); 
	}
		
	void Update () 
	{  
        if (input.GetMouseLeft)
		{            
            if (!EventSystem.current.IsPointerOverGameObject ()) 
			{
				if (!editorObjectSpawner.GetIsPreviewing) {

                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit.collider != null)
                    {
                        objSelector = hit.transform.GetComponent<ObjectSelect>();
                        Editor_ObjectMouseFollower editorObjectFollower = hit.transform.GetComponent<Editor_ObjectMouseFollower>();
                        
                        if (!objSelector.GetButtonSelected)
                        {
                            hit.transform.name= "Object-Preview";
                            objSelector.selectObject();
                        }
                        else if(objSelector.GetButtonSelected)
                        {
                            Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                            editorObjectFollower.GetOffset = pos;
                            hit.transform.name = objSelector.GetObjectName;
                            objSelector.placeObject(pos);
                        }
                    }

                    print("Cant place object, please select a object in your inventory.");
					return;
				}
                else if(editorObjectSpawner.GetIsPreviewing)
                {
                    editorObjectSpawner.PlaceObject(editorObjectSpawner.GetItemInHand, editorObjectSpawner.GetObjName);
                    if (!editorObjectSpawner.GetIsPlaced) 
					{
						print ("Cant select a object while holding a object in your hand!");
                    }
                    if(editorObjectSpawner.GetIsPlaced)
                        editorObjectSpawner.GetMyInventory.removeItem((Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), editorObjectSpawner.GetMyInventoryUI.GetCurrentType), editorObjectSpawner.GetObjName);
                }
			}
		}
        if (input.GetMouseRight)
        {
            if (editorObjectSpawner.GetIsPreviewing)
            {
                Destroy(editorObjectSpawner.GetItemInHand);
                editorObjectSpawner.GetItemInHand = null;
            }
            else if (objSelector.GetButtonSelected)
                objSelector.deselectObject();
        }
        
    }
}

