using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    private Editor_SpawnObject myEditorSpawnObject;

    private Button btn;
    private GameObject myObj;

    private void Start()
    {
        myEditorSpawnObject = FindObjectOfType<Editor_SpawnObject>();
        btn = GetComponent<Button>();

        myObj = (GameObject)Resources.Load("Inventory_Items/Chairs/da2");

        btn.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(myObj); });
    }
}
