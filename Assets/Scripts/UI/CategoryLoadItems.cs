using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryLoadItems : MonoBehaviour {

    [SerializeField]private GameObject shopPanel;
    [SerializeField]private RectTransform shopPanelRectTransform;
    [SerializeField]private Vector2 buttonOffset;
    [SerializeField]private int buttonSize;

    private CreateItem createItem;

    private void Start()
    {
        Vector2 panelSize = new Vector2( 3*(buttonSize + buttonOffset.x) + buttonOffset.x, Screen.height / 2);
        createItem = GetComponent<CreateItem>();
    }

    public void loadItems(string type)
    {
        Object[] itemsInFolder = Resources.LoadAll("Items/"+type+"/");
        print(itemsInFolder.Length);
        Vector2 screenPos = new Vector2(buttonOffset.x, -buttonOffset.y);
        for (int i = 0; i < itemsInFolder.Length; i++)
        {
            GameObject buttonGO = new GameObject();
            RectTransform buttonRT = buttonGO.AddComponent<RectTransform>();
            buttonRT.SetParent(shopPanel.transform);

            
            buttonGO.name = "Button" + i;

            buttonRT.sizeDelta = new Vector2(buttonSize, buttonSize);

            buttonRT.pivot = new Vector2(0, 1);
            buttonRT.anchorMin = new Vector2(0, 1);
            buttonRT.anchorMax = new Vector2(0, 1);

            buttonRT.anchoredPosition = screenPos;

            if (buttonRT.anchoredPosition.x >= shopPanelRectTransform.rect.width)
            {
                screenPos = new Vector2(buttonOffset.x, buttonRT.anchoredPosition.y - buttonRT.sizeDelta.y - buttonOffset.y-10);
                buttonRT.anchoredPosition = screenPos;
            }
            screenPos += new Vector2(buttonRT.sizeDelta.x + buttonOffset.x, 0);

            Button buttonBU = buttonGO.AddComponent<Button>();
            buttonBU.onClick.AddListener(() => { Debug.Log("button clicked: " + buttonGO.name); createItem.CreateMyItem("Chair",Item.ItemType.Chairs); });
            Image buttonIM = buttonGO.AddComponent<Image>();

            // Button Label
            GameObject label = new GameObject();
            RectTransform labelRT = label.AddComponent<RectTransform>();
            labelRT.SetParent(buttonGO.transform);
            labelRT.anchoredPosition = new Vector2(buttonRT.sizeDelta.x/2, -buttonRT.sizeDelta.y-15);
            Text labelText = label.AddComponent<Text>();
            labelText.font = Resources.Load<Font>("Fonts/Andale Mono");
            labelText.text = "TEST";
            labelText.color = Color.black;
        }
    }
}
