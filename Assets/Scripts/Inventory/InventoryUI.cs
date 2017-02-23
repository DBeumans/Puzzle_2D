﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour 
{
    [SerializeField]private GameObject inventoryPanel;
    private RectTransform invPanelRectTransform;
	private Inventory inventory;

    [SerializeField]private Vector2 buttonOffset;
    [SerializeField]private int buttonsInRow;

    [SerializeField]private int buttonSize;

    private GameObject buttonGO = null;
    private RectTransform buttonRT;
    private Button buttonBU;
    private Image buttonIMG;

    [SerializeField]private string currType;

    private void Awake()
	{
		inventory = GetComponent<Inventory> ();
        invPanelRectTransform = inventoryPanel.GetComponent<RectTransform>();

        Vector2 panelSize = new Vector2( buttonsInRow * (buttonSize + buttonOffset.x) + buttonOffset.x,buttonOffset.y);
        
        invPanelRectTransform.sizeDelta = panelSize;

        //updateUI();
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
            
            GameObject buttonGO = new GameObject();
            buttonGO.name = objName[i];
            RectTransform buttonRT = buttonGO.AddComponent<RectTransform>();
            buttonRT.SetParent(inventoryPanel.transform);
            buttonRT.sizeDelta = new Vector2(buttonSize, buttonSize);

            buttonRT.pivot = new Vector2(0, 1);
            buttonRT.anchorMin = new Vector2(0, 1);
            buttonRT.anchorMax = new Vector2(0, 1);

            buttonRT.anchoredPosition = screenPos;

            if (buttonRT.anchoredPosition.x >= invPanelRectTransform.rect.width)
            {
                screenPos = new Vector2(buttonOffset.x, buttonRT.anchoredPosition.y -buttonRT.sizeDelta.y - buttonOffset.y);
                buttonRT.anchoredPosition = screenPos;
            }
            screenPos += new Vector2(buttonRT.sizeDelta.x + buttonOffset.x, 0);

            Button buttonBU = buttonGO.AddComponent<Button>(); 
            Image buttonIMG = buttonGO.AddComponent<Image>();
            InventoryButton invButton = buttonGO.AddComponent<InventoryButton>();
            invButton.GetObjName = objName[i];
            invButton.GetObjType = currType;

        }
        
    }
}
