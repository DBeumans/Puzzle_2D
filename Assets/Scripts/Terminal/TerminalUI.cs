using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour 
{
    [SerializeField]private GameObject terminal;
    [SerializeField]private Button closeButton;
    [SerializeField]private Button minimizeButton;

    private ShowOutput output;
    private DesktopUI desktopUI;
    private FetchTerminalInput terminalInput;

    private void Start()
    {
        setReferences();
        desktopUI.OnTerminalPress += enableTerminal;

        closeButton.onClick.AddListener(delegate(){enableTerminal(false); terminalInput.resetInput(); output.clear();});
        minimizeButton.onClick.AddListener(delegate(){enableTerminal(false);});
        enableTerminal(false);
    }

    private void setReferences()
    {
        output = this.GetComponent<ShowOutput>();
        desktopUI = this.GetComponent<DesktopUI>();
        terminalInput = this.GetComponent<FetchTerminalInput>();
    }

    public void enableTerminal(bool value)
    {
        terminal.SetActive(value);
        terminalInput.enableInput(value);
    }
}
