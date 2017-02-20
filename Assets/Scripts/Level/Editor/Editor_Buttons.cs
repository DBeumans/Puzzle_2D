using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor_Buttons : MonoBehaviour {

    [SerializeField]private Button btn1;
    [SerializeField]private Button btn2;

    private void Start()
    {
        btn1.onClick.AddListener(delegate () {  });
        btn2.onClick.AddListener(delegate () {  });
    }
}

