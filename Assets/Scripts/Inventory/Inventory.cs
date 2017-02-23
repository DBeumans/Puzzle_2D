using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	private Dictionary <Item.ItemType,List<Item>> inventory = new Dictionary<Item.ItemType,List<Item>>();
	private int healthPotions;
	public int GetHealthPotions{get{return healthPotions;}}

    private InventoryUI myInventoryUI;

	private void Awake()
	{
		healthPotions = 0;
        Item chair = new Item("Health Potion", Item.ItemType.Furniture);
    }

    private void Start()
    {
        myInventoryUI = GetComponent<InventoryUI>();
    }

	public void AddItem (Item item)
	{
		if (!inventory.ContainsKey (item.Type))
		{
			inventory.Add (item.Type, new List<Item> ());
		}
		inventory[item.Type].Add(item);
		updateValues ();
	}

	private void updateValues()
	{
		List<Item> items = GetAllItemsOfType (Item.ItemType.Furniture);
		int temp = 0;
		for (int i = 0; i < items.Count; i++)
		{
			if (items [i].Name == "Chair")
			{
				temp++;
			}
		}
		healthPotions = temp;
        Debug.Log(healthPotions);
        myInventoryUI.updateUI();
	}

	public void removeItem(Item.ItemType itemType, string itemName)
	{
		for (int i = 0; i < inventory [itemType].Count; i++)
		{
			if (inventory [itemType] [i].Name == itemName)
			{
				inventory [itemType].RemoveAt (i);
				break;
			}
		}
		updateValues ();
	}
		
	public List<Item> GetAllItemsOfType(Item.ItemType type)
	{
		return inventory[type];
	}
}
