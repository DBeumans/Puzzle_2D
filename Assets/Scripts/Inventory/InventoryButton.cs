using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    private Editor_SpawnObject myEditorSpawnObject;
    private Inventory myInventory;

    private Button btn;
    private GameObject myObj;
    private Image myImage;

    private string objType;
    private string objName;

    public string GetObjName { get { return objName; } set { objName = value; objName = objName.ToLower(); } }
    public string GetObjType { get { return objType; } set { objType = value; } }
    private void Start()
    {
        myInventory = FindObjectOfType<Inventory>();
        myEditorSpawnObject = FindObjectOfType<Editor_SpawnObject>();
        btn = GetComponent<Button>();
        myImage = GetComponent<Image>();

        myImage.sprite = Resources.Load<Sprite>("Inventory_Items_Images/" + objType + "/" + objName);
        myObj = (GameObject)Resources.Load("Inventory_Items/"+objType+"/" + objName);

        if (myObj == null)
        {
            throw new System.Exception("Failed to load Item resource!");
        }
        if(myImage == null)
        {
            throw new System.Exception("Failed to load Item Image resource!");
        }

        btn.onClick.AddListener(delegate () { myEditorSpawnObject.PreviewObject(myObj,objName);});
        print(objName);
    }
}
