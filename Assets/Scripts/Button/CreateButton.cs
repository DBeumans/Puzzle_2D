using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour {

    public static GameObject createMyButton(string btnName, Vector2 btnSize, string spritePath, Vector2 btnPos, bool setLabel)
    {
        GameObject btn = new GameObject();
        RectTransform btnRect = btn.AddComponent<RectTransform>();
        Button btnButton = btn.AddComponent<Button>();
        Image btnImage = btn.AddComponent<Image>();

        btn.gameObject.name = btnName;
        btnRect.sizeDelta = btnSize;

        btnImage.sprite = Resources.Load<Sprite>(spritePath);

        if(setLabel)
        {
            GameObject label = new GameObject();
            RectTransform labelRT = label.AddComponent<RectTransform>();
            labelRT.SetParent(btn.transform);
            labelRT.anchoredPosition = new Vector2(btnRect.sizeDelta.x / 2, -btnRect.sizeDelta.y - 15);
            Text labelText = label.AddComponent<Text>();
            labelText.font = Resources.Load<Font>("Fonts/Andale Mono");
            labelText.text = btnName;
            labelText.color = Color.black;
        }

        return btn;
    }
}
