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

    private bool isLogout;
    public bool GetIsLogout {get{return isLogout;} set{isLogout = value;}}

	private void Start()
	{
        terminalIcon.onClick.AddListener (delegate(){if(OnTerminalPress != null) OnTerminalPress(true);});
        xplorerIcon.onClick.AddListener (delegate(){if(OnXplorerPress != null) OnXplorerPress(true);});
        quitButton.onClick.AddListener(delegate () {logOut(); if(OnQuitPress != null) OnQuitPress();});
	}

    private void logOut()
    {
        computer.SetActive(false);
        isLogout = true;
    }
}
