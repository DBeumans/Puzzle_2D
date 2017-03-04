using UnityEngine;
using UnityEngine.UI;

public class Editor_Buttons : MonoBehaviour {

    [SerializeField]private Button btn1;
    [SerializeField]private Button btn2;
    private Inventory myInventory;


    private void Start()
    {
        myInventory = GetComponent<Inventory>();

        btn1.onClick.AddListener(delegate () { myInventory.updateValues(Item.ItemType.Chairs); });
        btn2.onClick.AddListener(delegate () { myInventory.updateValues(Item.ItemType.Couches); });
    }
}

