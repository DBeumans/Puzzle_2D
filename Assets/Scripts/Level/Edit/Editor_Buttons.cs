using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor_Buttons : MonoBehaviour {

    [SerializeField]private Button btn1;
    [SerializeField]private Button btn2;

    private Editor_SpawnObject myEditorSpawnObject;

    [SerializeField]private List<GameObject> furnitureObjects = new List<GameObject>();


    private void Start()
    {
        myEditorSpawnObject = GetComponent<Editor_SpawnObject>();

        btn1.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(furnitureObjects[0]); });
        btn2.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(furnitureObjects[1]); });
    }
}

