using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour {

    private InteractionText myInteractionText;

    private bool canSwitch = false;
    [SerializeField]private bool isTouchingSomething = false;

    public bool GetCanSwitch { get { return canSwitch; } }
    public bool GetIsTouching { get { return isTouchingSomething; } }

    private void Start()
    {
        myInteractionText = FindObjectOfType<InteractionText>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Computer_Trigger")
        {
            myInteractionText.SetInteractionText("Press E to access your computer.");
            canSwitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        myInteractionText.SetInteractionText("");
        canSwitch = false;
        isTouchingSomething = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != this.gameObject.tag)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
                isTouchingSomething = true;

        }
    }
}
