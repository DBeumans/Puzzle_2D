using UnityEngine;
using UnityEngine.UI;

public enum XplorerTab
{
    Webshop = 0,
    NationalBank = 1,
    SecondBank = 2,
    Keylogger = 3,
    Close = 4
}

public class xplorerUI : MonoBehaviour 
{
    [SerializeField]private GameObject xplorerObject;
    [SerializeField]private Button closeButton;

	[Tooltip("All the browser tab buttons")]
	[SerializeField]private Button[] tabs;

	[Tooltip("All the windows")]
	[SerializeField]private GameObject[] windowPanels;

    private DesktopUI desktopUI;

	private void Start()
	{
        desktopUI = this.GetComponent<DesktopUI>();
        desktopUI.OnXplorerPress += this.showXplorer;
		setButtonListeners ();
        showXplorer(false);
	}

	private void setButtonListeners()
	{
        tabs[0].onClick.AddListener(delegate(){showTab(XplorerTab.Webshop);});
        tabs[1].onClick.AddListener(delegate(){showTab(XplorerTab.NationalBank);});
        tabs[2].onClick.AddListener(delegate(){showTab(XplorerTab.SecondBank);});
        tabs[3].onClick.AddListener(delegate(){showTab(XplorerTab.Keylogger);});
        closeButton.onClick.AddListener(delegate(){showXplorer(false);});
	}

    public void showXplorer(bool value)
    {
        xplorerObject.SetActive(value);
        if(value)
            showTab (XplorerTab.Webshop);
    }

    private void showTab(XplorerTab tab)
	{
		for (var i = 0; i < windowPanels.Length; i++)
		{
			windowPanels[i].SetActive (false);

			var stdColour = tabs [i].colors;
			stdColour.normalColor = Color.gray;
			tabs [i].colors = stdColour;
		}
        var tabToShow = (int)tab;
        windowPanels [tabToShow].SetActive (true);

        var selectedColour = tabs [tabToShow].colors;
		selectedColour.normalColor = new Color (0.9f,0.4f,0.4f);
		selectedColour.highlightedColor = new Color (0.9f,0.4f,0.4f);
		selectedColour.pressedColor = new Color (0.9f,0.4f,0.4f);
		selectedColour.disabledColor =  new Color (0.9f,0.4f,0.4f);
        tabs [tabToShow].colors = selectedColour;
	}
}
