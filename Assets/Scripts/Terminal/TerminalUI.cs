using System.Collections;

using UnityEngine;

public class TerminalUI : MonoBehaviour 
{
    [SerializeField]private GameObject terminal;

    private DesktopUI desktopUI;
    private FetchTerminalInput terminalInput;

    private void Start()
    {
        setReferences();
        desktopUI.OnTerminalPress += enableTerminal;
        enableTerminal(false);
    }

    private void setReferences()
    {
        desktopUI = this.GetComponent<DesktopUI>();
        terminalInput = this.GetComponent<FetchTerminalInput>();
    }

    public void enableTerminal(bool value)
    {
        terminal.SetActive(value);
        terminalInput.enableInput(value);
    }
}
