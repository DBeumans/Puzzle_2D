using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ButtonColors : MonoBehaviour {

    [SerializeField]private ColorBlock myColor;

    private Color myNormalColor;
    public Color GetMyNormalColor { get { return myNormalColor; } set { myNormalColor = value; } }

    private Color myHighlightedColor;
    public Color GetMyHighlightedColor { get { return myHighlightedColor; } set { myHighlightedColor = value; } }

    private Color myDisabledColor;
    public Color GetMyDisabledColor { get { return myDisabledColor; } set { myDisabledColor = value; } }

    private Color myPressedColor;
    public Color GetMyPressedColor { get { return myPressedColor; } set { myPressedColor = value; } }

    private float myAlphaValue =.5f;
    public float GetMyAlphaValue { get { return myAlphaValue; } set { myAlphaValue = value; } }

    private float myFadeDuration = .1f;
    public float GetMyFadeDuration { get { return myFadeDuration; } set { if (value > 1) value = 1; myFadeDuration = value; } }

    private float myColorMultiplier = 1;
    public float GetMyColorMultiplier { get { return myColorMultiplier; } set { if (value > 5) value = 5; myColorMultiplier = value; } }

    Button btn;
    
	private void Start()
    {
        StartCoroutine(setColors());
    }
		
	// OnMouse Enter Function etc gebruiken.
    IEnumerator setColors()
    {
        while(true)
        {
            if(btn==null)
                btn = GetComponent<Button>();

            if (btn != null)
            {
                myNormalColor.a = myAlphaValue;
                myHighlightedColor.a = myAlphaValue;
                myDisabledColor.a = myAlphaValue;
                myPressedColor.a = myAlphaValue;

                myColor.normalColor = myNormalColor;
                myColor.highlightedColor = myHighlightedColor;
                myColor.disabledColor = myDisabledColor;
                myColor.pressedColor = myPressedColor;

                myColor.colorMultiplier = 1;

                myColor.fadeDuration = myFadeDuration;

                btn.colors = myColor;
            }
            
            yield return new WaitForSeconds(1f);
        }
    }
    
}
