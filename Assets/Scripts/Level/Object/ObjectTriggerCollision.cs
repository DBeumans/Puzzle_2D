﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTriggerCollision : MonoBehaviour {

    private bool canPlaceObject = true;

    public bool GetCanPlaceObject { get { return canPlaceObject; } }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == this.gameObject.name)
        {
            canPlaceObject = false;
            return;
        }
        canPlaceObject = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPlaceObject = true;
    }
}
