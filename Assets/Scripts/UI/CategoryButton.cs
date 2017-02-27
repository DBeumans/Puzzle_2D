using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CategoryButton : MonoBehaviour {
    
    Button btn;
    CategoryLoadItems loadItems;

	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        loadItems = FindObjectOfType<CategoryLoadItems>();
        btn.onClick.AddListener(delegate () { loadItems.loadItems(btn.gameObject.name); });
	}
}
