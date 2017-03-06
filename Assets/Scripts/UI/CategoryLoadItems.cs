using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryLoadItems : MonoBehaviour {

    [SerializeField]private GameObject shopPanel;
    [SerializeField]private RectTransform shopPanelRectTransform;
    [SerializeField]private Vector2 buttonOffset;
    [SerializeField]private int buttonSize;
    [SerializeField]private int buttonsInRow;

    private CreateItem createItem;

    private void Start()
    {

        Vector2 panelSize = new Vector2(buttonsInRow * (buttonSize + buttonOffset.x) + buttonOffset.x, Screen.height/2+Screen.height/4);

        shopPanelRectTransform.sizeDelta = panelSize;
        createItem = GetComponent<CreateItem>();

    }

    public void loadItems(Item.ItemType type)
    {
        Object[] itemsInFolder = Resources.LoadAll("Items/"+type.ToString()+"/");

        Vector2 screenPos = new Vector2(buttonOffset.x, -buttonOffset.y);

        int childs = shopPanel.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            Destroy(shopPanel.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < itemsInFolder.Length; i++)
        {
			GameObject btn = ButtonFactory.createButton(itemsInFolder[i].name, new Vector2(buttonSize, buttonSize), Paths.ItemSprite+type+"/"+itemsInFolder[i].name, screenPos, true);
            btn.transform.SetParent(shopPanel.transform);

            RectTransform btnRect = btn.GetComponent<RectTransform>();
            Button btnButton = btn.GetComponent<Button>();
          
            btnRect.pivot = new Vector2(0, 1);
            btnRect.anchorMin = new Vector2(0, 1);
            btnRect.anchorMax = new Vector2(0, 1);

            btnRect.anchoredPosition = screenPos;

            if (btnRect.anchoredPosition.x >= shopPanelRectTransform.rect.width)
            {
                screenPos = new Vector2(buttonOffset.x, btnRect.anchoredPosition.y - btnRect.sizeDelta.y - buttonOffset.y - 10);
                btnRect.anchoredPosition = screenPos;
            }
            screenPos += new Vector2(btnRect.sizeDelta.x + buttonOffset.x, 0);
            btnButton.onClick.AddListener(delegate () { createItem.CreateMyItem(btn.name, type); });

            shopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -btnRect.anchoredPosition.y + btnRect.sizeDelta.y + buttonOffset.y);

            /*
            GameObject buttonGO = new GameObject();
            RectTransform buttonRT = buttonGO.AddComponent<RectTransform>();
            buttonRT.SetParent(shopPanel.transform);

            buttonGO.name = itemsInFolder[i].name;

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
            buttonBU.onClick.AddListener(() => {createItem.CreateMyItem(buttonGO.name,type); });
            Image buttonIM = buttonGO.AddComponent<Image>();
            buttonIM.sprite = Resources.Load<Sprite>("Items_Images/" + type + "/" + itemsInFolder[i].name);
            // Button Label
            GameObject label = new GameObject();
            RectTransform labelRT = label.AddComponent<RectTransform>();
            labelRT.SetParent(buttonGO.transform);
            labelRT.anchoredPosition = new Vector2(buttonRT.sizeDelta.x/2, -buttonRT.sizeDelta.y-15);
            Text labelText = label.AddComponent<Text>();
            labelText.font = Resources.Load<Font>("Fonts/Andale Mono");
            labelText.text = itemsInFolder[i].name;
            labelText.color = Color.black;
            */
        }
    }
}
