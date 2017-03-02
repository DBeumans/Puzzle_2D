using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Editor_MouseInput : MonoBehaviour {

	InputBehaviour input;
	Editor_SpawnObject editorObjectSpawner;

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
					if(editorObjectSpawner.GetIsPlaced)
					{
						// raycast.
						RaycastHit hit;
						Ray ray;
						if(Physics.Raycast(ray, out hit,50))
						{
							Debug.Log (hit.transform.name);
						}
						// Selecting item
						//selectObject ();
						//print ("Object Selected");
					}

					//print("Cant place object, please select a object in your inventory.");
					//return;
				} else {
					if (!editorObjectSpawner.GetIsPlaced) 
					{
						//print ("Cant select a object while holding a object in your hand!");
					}
					//PlaceObject(itemInHand,objName);
				}
				if (editorObjectSpawner.GetIsPlaced)
				{
					// deleting item in inventory.
					//myInventory.removeItem((Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), myInventoryUI.GetCurrentType ) , objName);
				}
			}
		}
	}
}

