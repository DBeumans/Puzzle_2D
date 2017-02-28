using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour {

    Inventory myInventory;

    private void Start()
    {
        myInventory = GetComponent<Inventory>();
    }

    public void CreateMyItem(string name, Item.ItemType type)
    {
        Item myitem = new Item(name, type);
        myInventory.AddItem(myitem);
    }
}
