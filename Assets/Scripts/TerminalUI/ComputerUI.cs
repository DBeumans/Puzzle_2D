using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour 
{
	[SerializeField]private GameObject terminal;
	[SerializeField]private Button terminalIcon;

	private void Start()
	{
		terminalIcon.onClick.AddListener (delegate(){enableTerminal(true);});	
	}

	private void enableTerminal(bool value)
	{
		terminal.SetActive (value);
		this.enabled = false;
	}
}
