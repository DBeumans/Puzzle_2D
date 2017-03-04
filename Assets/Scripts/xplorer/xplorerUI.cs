using UnityEngine;
using UnityEngine.UI;

public class xplorerUI : MonoBehaviour 
{
	[Tooltip("All the browser tab buttons")]
	[SerializeField]private Button[] tabs;

	[Tooltip("All the windows")]
	[SerializeField]private GameObject[] windowPanels;

	private void Start()
	{
		setButtonListeners ();
		showWindow (0);
	}

	private void setButtonListeners()
	{
		for(int i = 0; i<tabs.Length; i++)
		{
			int temp = i;
			tabs [i].onClick.AddListener (delegate() {showWindow(temp);});
		}
	}

	private void showWindow(int index)
	{
		for (int i = 0; i < windowPanels.Length; i++)
		{
			windowPanels[i].SetActive (false);

			var stdColour = tabs [i].colors;
			stdColour.normalColor = Color.gray;
			tabs [i].colors = stdColour;
		}
		windowPanels [index].SetActive (true);

		var selectedColour = tabs [index].colors;
		selectedColour.normalColor = new Color (0.9f,0.4f,0.4f);
		selectedColour.highlightedColor = new Color (0.9f,0.4f,0.4f);
		selectedColour.pressedColor = new Color (0.9f,0.4f,0.4f);
		selectedColour.disabledColor =  new Color (0.9f,0.4f,0.4f);
		tabs [index].colors = selectedColour;
	}
}
