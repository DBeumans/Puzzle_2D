﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour 
{
	[SerializeField]private GameObject terminal;
	[SerializeField]private GameObject xplorer;
    [SerializeField]private GameObject computer;
	[SerializeField]private Button terminalIcon;
	[SerializeField]private Button xplorerIcon;
	[SerializeField]private Button quitExplorer;
    [SerializeField]private Button quitButton;

    private bool isLogout;
    public bool GetIsLogout {get{return isLogout;}set{isLogout = value;}}

	private void Start()
	{
		terminalIcon.onClick.AddListener (delegate(){enableTerminal(true);});
		xplorerIcon.onClick.AddListener (delegate(){enableXplorer(true);});
        quitButton.onClick.AddListener(delegate () {logOut();});
		quitExplorer.onClick.AddListener (delegate(){enableXplorer (false);});
		enableTerminal (false);
		enableXplorer (false);
	}

	public void enableTerminal(bool value)
	{
		terminal.SetActive (value);
		enabled = false;
	}

	public void enableXplorer(bool value)
	{
		xplorer.SetActive (value);
		enabled = false;
	}

    private void logOut()
    {
        computer.SetActive(false);
        isLogout = true;
    }
}
