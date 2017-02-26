using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Editor_SpawnObject : MonoBehaviour {

    private GameObject itemInHand;
    private Inventory myInventory;
    [SerializeField]private bool isPreviewing;

    [SerializeField]private Vector3 mousePos;

    private ObjectTriggerCollision objCollision;
    [SerializeField]private GameObject myParent;
    private string objName;

    private void Start()
    {
        itemInHand = null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

        myInventory = GetComponent<Inventory>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (!isPreviewing)
                {
                    print("Cant place object, please select a object in your inventory.");
                    return;
                }
                
                PlaceObject(itemInHand,objName);
                myInventory.removeItem(Item.ItemType.Chairs, objName);
}
        }
    }

    public void PreviewObject(GameObject previewObj,string objName)
	{
        this.objName = objName;
        if (itemInHand != null)
        {
            Destroy(itemInHand);
            itemInHand = previewObj;
        }
        itemInHand = previewObj;

        GameObject obj = Instantiate(itemInHand, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
        itemInHand = obj;
        obj.GetComponent<Editor_ObjectMouseFollower>().GetFoll = true;
        obj.gameObject.name = "Object-Preview";
        isPreviewing = true;

    }

	public void PlaceObject(GameObject myObject,string ObjName)
	{

        objCollision = GameObject.Find("Object-Preview").GetComponent<ObjectTriggerCollision>();
        if (!objCollision.GetCanPlaceObject)
        {
            print("Cant place object in a other object!");
            return;
        }
        else
        {
            GameObject obj = Instantiate(myObject);
            myObject.transform.position = new Vector3(itemInHand.transform.position.x, itemInHand.transform.position.y,-5);
            obj.GetComponent<Editor_ObjectMouseFollower>().GetFoll = false;
            obj.gameObject.name = ObjName;
            obj.AddComponent<BoxCollider2D>();
            Destroy(obj.GetComponent<ObjectTriggerCollision>());
            obj.GetComponent<Editor_ObjectMouseFollower>().GetOffset = myObject.transform.position;
            obj.transform.SetParent(myParent.transform);
            // verwijder preview object, zet item in hand naar null

            Destroy(itemInHand);
            itemInHand = null;
            isPreviewing = false;

        }
    }
}
