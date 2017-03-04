using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_ObjectMouseFollower : MonoBehaviour {
    private bool foll = false;

    public bool GetFoll { get { return foll; } set { foll = value; } }

    private ObjectSelect objSelect;

    private void Start()
    {
        objSelect = GetComponent<ObjectSelect>();
    }

    private void Update()
    {
        if (!foll)
        {
            this.transform.position = objSelect.GetLastPos;
            return;
        }
            
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y, 5));
        this.transform.position = mousePos;
    }
}

