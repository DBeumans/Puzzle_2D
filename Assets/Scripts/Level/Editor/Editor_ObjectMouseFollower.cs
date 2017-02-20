using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_ObjectMouseFollower : MonoBehaviour {

    public GameObject particle;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(particle, transform.position, transform.rotation);
        }
    }
}

