using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_SpawnObject : MonoBehaviour {

    public GameObject cuber;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            print(Input.mousePosition);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

            GameObject obj = Instantiate(cuber, new Vector3(mousePos.x, mousePos.y, 0.0f), Quaternion.identity);
            obj.GetComponent<Editor_ObjectMouseFollower>().foll = true;
            obj.GetComponent<Editor_ObjectMouseFollower>().GetMyObject = obj;
        }
    }

    public void PreviewObject(GameObject previewObj)
	{
        // instantiate @ spawn pos.
       // GameObject obj = Instantiate(previewObj);
	}

	public void PlaceObject()
	{

	}
}
