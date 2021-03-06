﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour 
{
    [SerializeField]private GameObject inventoryPanel;
    [SerializeField]private RectTransform invPanelRectTransform;
	private Inventory inventory;

    [SerializeField]private Vector2 buttonOffset;
    [SerializeField]private int buttonsInRow;

    [SerializeField]private int buttonSize;

    [SerializeField]private string currType;

    public string GetCurrentType { get { return currType; } }

    private void Awake()
	{
		inventory = GetComponent<Inventory> ();

        Vector2 panelSize = new Vector2( buttonsInRow * (buttonSize + buttonOffset.x) + buttonOffset.x,Screen.height/2);
        
        invPanelRectTransform.sizeDelta = panelSize;
	}
	public void updateUI(int itemsToShow, string type, List<string> objName)
	{
        if (currType != type || currType == type)
        {
            int childs = inventoryPanel.transform.childCount;
            for (int i = 0; i < childs; i++)
            {
                Destroy(inventoryPanel.transform.GetChild(i).gameObject);
                currType = "";
                
            }          
            
        }

        currType = type;
        Vector2 screenPos = new Vector2(buttonOffset.x, -buttonOffset.y);

        for (int i = 0; i < itemsToShow; i++)
        {

			GameObject btn = ButtonFactory.createButton(objName[i], new Vector2(buttonSize, buttonSize), null, screenPos, false);
            RectTransform btnRect = btn.GetComponent<RectTransform>();
            Button btnButton = btn.GetComponent<Button>();
            InventoryButton invButton = btn.AddComponent<InventoryButton>();

            btnRect.SetParent(inventoryPanel.transform);
            
            btnRect.pivot = new Vector2(0, 1);
            btnRect.anchorMin = new Vector2(0, 1);
            btnRect.anchorMax = new Vector2(0, 1);
            btnRect.localScale = new Vector3(1, 1, 1);
            btnRect.anchoredPosition = screenPos;

            if (btnRect.anchoredPosition.x >= invPanelRectTransform.rect.width)
            {
                screenPos = new Vector2(buttonOffset.x, btnRect.anchoredPosition.y - btnRect.sizeDelta.y - buttonOffset.y);
                btnRect.anchoredPosition = screenPos;
            }
            screenPos += new Vector2(btnRect.sizeDelta.x + buttonOffset.x, 0);

            invButton.GetObjName = objName[i];
            invButton.GetObjType = currType;
            inventoryPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -btnRect.anchoredPosition.y + btnRect.sizeDelta.y + buttonOffset.y);
        }

    }
}
