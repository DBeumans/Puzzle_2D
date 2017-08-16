using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour {

    [SerializeField]private Text myTextObject;

    private void Start()
    {
        myTextObject.text = "";
    }

    public void SetInteractionText(string text)
    {
        myTextObject.text = text;
    }
}
