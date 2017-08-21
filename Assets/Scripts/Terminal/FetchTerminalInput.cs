using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FetchTerminalInput : MonoBehaviour 
{
	[SerializeField]private InputField inputField;
	private CheckTerminalInput checkInput;
	private ShowOutput output;
    private TerminalScrollLogic scroll;
	private AutoComplete autocomplete;
    private SelectCommand commands;

	private int index;
	private bool active;

	private void Awake()
	{
        setReferences();
		index = 0;
		active = false;
		resetInput ();
	}

    private void setReferences()
    {
        output = this.GetComponent<ShowOutput> ();
        scroll = this.GetComponent<TerminalScrollLogic> ();
        checkInput = GameObject.FindGameObjectWithTag(Tags.terminal).GetComponent<CheckTerminalInput>();
        autocomplete = this.GetComponent<AutoComplete>();
        commands = this.GetComponent<SelectCommand>();
    }

	private void Update()
	{
        if (!active)
            return;
        
        if (!inputField.enabled)
            return;
        
        if (Input.GetKeyDown (KeyCode.Return))
		{
			output.addText (inputField.text, true);
			checkInput.CheckInput (inputField.text);
			resetInput ();
			scroll.updateScroll ();
		}

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputField.text = commands.getCommand(-1);
            resetCaret();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputField.text = commands.getCommand(1);
            resetCaret();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            autocomplete.complete();
            resetCaret();
        }
	}

    public void resetInput()
	{
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
		inputField.OnPointerClick(new PointerEventData(EventSystem.current));
		index = checkInput.getPreviousCommands.Count;
	}

	private void resetCaret(){inputField.caretPosition = inputField.text.Length;}

	public void enableInput(bool value)
	{
		inputField.enabled = value;
		active = value;
		resetCaret ();
	}
}
