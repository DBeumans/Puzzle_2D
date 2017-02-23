using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor_Buttons : MonoBehaviour {

    [SerializeField]private Button btn1;
    [SerializeField]private Button btn2;

    private Editor_SpawnObject myEditorSpawnObject;
    private Inventory myInventory;

    //[SerializeField]private List<GameObject> furnitureObjects = new List<GameObject>();


    private void Start()
    {

        myEditorSpawnObject = GetComponent<Editor_SpawnObject>();
        myInventory = GetComponent<Inventory>();
        /*
        btn1.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(furnitureObjects[0]); });
        btn2.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(furnitureObjects[1]); });
        */
        /*
        btn1.onClick.AddListener(delegate () { Item chair = new Item("Chair", Item.ItemType.Furniture);
                                               myInventory.AddItem(chair); });

        btn2.onClick.AddListener(delegate () { Item couch = new Item("Couch", Item.ItemType.Furniture);
                                               myInventory.AddItem(couch); });
        */
    }
    public void onClick(Button btn, GameObject obj)
    {
        btn.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(obj); });
    }
}

