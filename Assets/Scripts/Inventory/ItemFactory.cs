using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {
	
    Inventory myInventory;

    private void Start()
    {
        myInventory = GetComponent<Inventory>();
    }

    public void CreateItem(string name, Item.ItemType type)
    {
        Item myitem = new Item(name, type);
        myInventory.AddItem(myitem);
    }
}
