using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Editor_SpawnObject : MonoBehaviour {

    private GameObject itemInHand;
    private Inventory myInventory;
    private InventoryUI myInventoryUI;
    private InputBehaviour input;

    [SerializeField]private bool isPreviewing;
    private bool isPlaced;

    [SerializeField]private Vector3 mousePos;

    private ObjectTriggerCollision objCollision;
    [SerializeField]private GameObject myParent;
    private string objName;

    private void Start()
    {
        input = GetComponent<InputBehaviour>();
        itemInHand = null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

        myInventory = GetComponent<Inventory>();
        myInventoryUI = GetComponent<InventoryUI>();
    }
    private void Update()
    {

        if (input.GetMouseLeft)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (!isPreviewing)
                {
                    print("Cant place object, please select a object in your inventory.");
                    return;
                }
                
                PlaceObject(itemInHand,objName);
                // deleting item in inventory.
                if (isPlaced)
                {
                    myInventory.removeItem((Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), myInventoryUI.GetCurrentType ) , objName);
                }
            }
        }
        else if(input.GetMouseRight)
        {
            if(isPreviewing)
            {
                Destroy(itemInHand);
                itemInHand = null;
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
        isPlaced = false;
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
            this.objName = ObjName;
            obj.AddComponent<BoxCollider2D>();
            Destroy(obj.GetComponent<ObjectTriggerCollision>());
            obj.GetComponent<Editor_ObjectMouseFollower>().GetOffset = myObject.transform.position;
            obj.transform.SetParent(myParent.transform);
            Destroy(itemInHand);
            isPreviewing = false;
            isPlaced = true;
            itemInHand = null;

        }
    }
}
