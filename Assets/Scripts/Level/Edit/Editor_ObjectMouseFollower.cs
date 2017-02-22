using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_ObjectMouseFollower : MonoBehaviour {

    [SerializeField]private Vector3 offset;
    private bool foll = false;

    public bool GetFoll { get { return foll; } set { foll = value; } }
    public Vector3 GetOffset { get { return offset; } set { offset = value; } }

    private void Update()
    {
        if (!foll)
        {
            this.transform.position = offset;
            return;
        }
            

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        this.transform.position = mousePos;
    }
}

