﻿using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class CategoryButton : MonoBehaviour {
    
    private Button btn;
    private CategoryLoadItems loadItems;
    // Use this for initialization
    private void Start () {
        btn = GetComponent<Button>();
        loadItems = FindObjectOfType<CategoryLoadItems>();
        btn.onClick.AddListener(delegate () { loadItems.loadItems((Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), this.gameObject.name)); });
        ButtonColors col = GetComponent<ButtonColors>();
        col.GetMyHighlightedColor = Color.yellow;
    }
}
