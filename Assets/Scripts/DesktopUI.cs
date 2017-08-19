using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class DesktopUI : MonoBehaviour 
{
	[SerializeField]private GameObject terminal;
	[SerializeField]private GameObject xplorer;
    [SerializeField]private GameObject computer;

	[SerializeField]private Button terminalIcon;
	[SerializeField]private Button xplorerIcon;
    [SerializeField]private Button quitButton;

    public Action<bool> OnTerminalPress;
    public Action<bool> OnXplorerPress;
    public Action OnQuitPress;

    private bool isLoggedOut;
    public bool IsLoggedOut {get{return isLoggedOut;} set{isLoggedOut = value;}}

	private void Start()
	{
        terminalIcon.onClick.AddListener (delegate(){if(OnTerminalPress != null) OnTerminalPress(true);});
        xplorerIcon.onClick.AddListener (delegate(){if(OnXplorerPress != null) OnXplorerPress(true);});
        quitButton.onClick.AddListener(delegate () {hideComputer(); if(OnQuitPress != null) OnQuitPress();});
	}

    private void hideComputer()
    {
        computer.SetActive(false);
        isLoggedOut = true;
    }
}
