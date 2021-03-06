﻿using System.Collections.Generic;

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
        autocomplete = new AutoComplete ();
    }

	private void Update()
	{
        if (!active)
            return;
		
        if (Input.GetKeyDown (KeyCode.Return))
		{
			output.addText (inputField.text, true);
			checkInput.CheckInput (inputField.text);
			resetInput ();
			scroll.updateScroll ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
			selectCommand (-1);

		if (Input.GetKeyDown (KeyCode.DownArrow))
		    selectCommand (1);

		if (Input.GetKeyDown (KeyCode.Tab))
		    setWord ();
	}

	private void setWord()
	{
		List<string> value = autocomplete.scan (inputField.text);
		if (value == null)
            return;

		if (value.Count == 1)
			inputField.text = value [0];
		else
		{
			output.addText ("Multiple possibilities for your input:",false);
			foreach (string word in value)
				output.addText (word, false);
		}
		resetCaret ();
	}

	private void resetInput()
	{
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        inputField.Select();
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

	private void selectCommand(int value)
	{
		index += value;
		if (index < 0)
			index = 0;

		if (index > checkInput.getPreviousCommands.Count - 1)
			index = checkInput.getPreviousCommands.Count - 1; 

		if (checkInput.getPreviousCommands.Count > 0)
			inputField.text = checkInput.getPreviousCommands [index];
		resetCaret ();
	}
}
