using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_ObjectMouseFollower : MonoBehaviour {

    private GameObject myObject;
    public bool foll;

    [SerializeField]private Vector3 offset;

    public GameObject GetMyObject { get { return myObject; } set { myObject = value; } }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset.z));
        this.transform.position = mousePos;
    }
}

