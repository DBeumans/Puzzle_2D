using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CategoryButton : MonoBehaviour {

    [SerializeField]
    Button btn;
    CategoryLoadItems loadItems;
	// Use this for initialization
	void Start () {
        loadItems = GetComponent<CategoryLoadItems>();

        btn.onClick.AddListener(delegate () { loadItems.loadItems("Chair"); });
	}
}
