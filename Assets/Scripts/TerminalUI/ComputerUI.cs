using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour 
{
	[SerializeField]private GameObject terminal;
    [SerializeField]private GameObject computer;
	[SerializeField]private Button terminalIcon;
    [SerializeField]private Button quitButton;

    private bool isLogout;

    public bool GetIsLogout { get { return isLogout; } set { isLogout = value; } }

	private void Start()
	{
		terminalIcon.onClick.AddListener (delegate(){enableTerminal(true);});
        quitButton.onClick.AddListener(delegate () { logOut(); });
	}

	public void enableTerminal(bool value)
	{
		terminal.SetActive (value);
		enabled = false;
	}

    private void logOut()
    {
        computer.SetActive(false);
        isLogout = true;
    }
}
