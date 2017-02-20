using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour {

    private InteractionText myInteractionText;

    private void Start()
    {
        myInteractionText = FindObjectOfType<InteractionText>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Computer_Trigger")
        {
            myInteractionText.SetInteractionText("Press E to access your computer.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        myInteractionText.SetInteractionText("");
    }
}
