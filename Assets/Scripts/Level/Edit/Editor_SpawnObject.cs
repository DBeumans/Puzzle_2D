using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Editor_SpawnObject : MonoBehaviour {

    private GameObject itemInHand;

    [SerializeField]private bool isPreviewing;

    [SerializeField]private Vector3 mousePos;

    private ObjectTriggerCollision objCollision;

    private string objName;

    private void Start()
    {

        itemInHand = null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
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

        objCollision = FindObjectOfType<ObjectTriggerCollision>();
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
            // Naam veranderen naar naam van het furniture object , referentie naar een data script waar dat genoteerd is.
            obj.gameObject.name = ObjName;
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<Editor_ObjectMouseFollower>().GetOffset = myObject.transform.position;
        }
    }
}
