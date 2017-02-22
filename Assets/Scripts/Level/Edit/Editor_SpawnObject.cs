using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Editor_SpawnObject : MonoBehaviour {

    /*
     * Als ik preview klik, moet er maar 1 object gespawnt worden.
     * bijhouden met een int.
     * wanneer ik een meubel wil previewen moet ik mijn prewview int check dat het niet groter dan 1 is.
     * als het kleiner dan 1 is tel ik het bij de functie op.
     * 
     * 
     */
    [SerializeField]private GameObject itemInHand;

    [SerializeField]private bool isPreviewing;

    [SerializeField]private Vector3 mousePos;

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


                PlaceObject(itemInHand);
            }
        }
    }

    public void PreviewObject(GameObject previewObj)
	{
        // instantiate @ spawn pos.
        // GameObject obj = Instantiate(previewObj);
        
        if (itemInHand != null)
        {
            Destroy(itemInHand);
            itemInHand = previewObj;
            //return;
        }
        itemInHand = previewObj;
        
        GameObject obj = Instantiate(itemInHand, new Vector3(mousePos.x, mousePos.y, 0.0f), Quaternion.identity);
        itemInHand = obj;
        obj.GetComponent<Editor_ObjectMouseFollower>().GetFoll = true;
        //obj.GetComponent<Editor_ObjectMouseFollower>().GetMyObject = obj;

        isPreviewing = true;


    }

	public void PlaceObject(GameObject myObject)
	{
        GameObject obj = Instantiate(myObject);
        myObject.transform.position = new Vector2(itemInHand.transform.position.x, itemInHand.transform.position.y);
        obj.GetComponent<Editor_ObjectMouseFollower>().GetFoll = false;
        obj.GetComponent<Editor_ObjectMouseFollower>().GetOffset = myObject.transform.position;
    }
}
