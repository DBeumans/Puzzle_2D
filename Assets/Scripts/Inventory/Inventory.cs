using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	private Dictionary <Item.ItemType,List<Item>> inventory = new Dictionary<Item.ItemType,List<Item>>();

    private InventoryUI myInventoryUI;

    List<string> itemName = new List<string>();

    private void Start()
    {
        myInventoryUI = GetComponent<InventoryUI>();
        quickItemCreation();
    }

    private void quickItemCreation()
    {
        Item chair = new Item("Chair", Item.ItemType.Chairs);
        Item chair6 = new Item("Chair", Item.ItemType.Chairs);
        Item chair1 = new Item("Chair2", Item.ItemType.Chairs);
        Item chair2 = new Item("Chair3", Item.ItemType.Chairs);
        Item chair3 = new Item("Chair4", Item.ItemType.Chairs);
        Item chair4 = new Item("Chair5", Item.ItemType.Chairs);

        Item couch = new Item("Couch", Item.ItemType.Couches);

        AddItem(chair);
        AddItem(chair6);
        AddItem(chair1);
        AddItem(chair2);
        AddItem(chair3);
        AddItem(chair4);
        AddItem(couch);
    }

    public void AddItem (Item item)
	{
		if (!inventory.ContainsKey (item.Type))
		{
			inventory.Add (item.Type, new List<Item> ());
		}
		inventory[item.Type].Add(item);
        updateValues(item.Type);
    }

	public void updateValues(Item.ItemType type)
	{
        itemName.Clear();
        List<Item> items = GetAllItemsOfType(type);

        for (int i = 0; i < items.Count; i++)
        {
            itemName.Add(items[i].Name);            
        }

        myInventoryUI.updateUI(items.Count, type.ToString(), itemName);
    }

	public void removeItem(Item.ItemType itemType, string itemName)
	{
		for (int i = 0; i < inventory[itemType].Count; i++)
		{
			if (inventory[itemType][i].Name == itemName)
			{
				inventory[itemType].RemoveAt (i);
				break;
			}
		}
		updateValues (itemType);
	}
		
	public List<Item> GetAllItemsOfType(Item.ItemType type)
	{
		return inventory[type];
	}
}
