﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FetchTerminalInput : MonoBehaviour 
{
	[SerializeField]private InputField inputField;
	private CheckTerminalInput checkInput;
	private ShowOutput output;
	private int index;

	private void Start()
	{
		checkInput = GetComponent<CheckTerminalInput> ();
		output = GetComponent<ShowOutput> ();
		index = 0;
		resetInput ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return))
		{
			output.addText (inputField.text,true);
			checkInput.checkInput (inputField.text);
			resetInput ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			selectCommand ();
		}
	}

	private void resetInput()
	{
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
		inputField.OnPointerClick(new PointerEventData(EventSystem.current));
		index = checkInput.getPreviousCommands.Count;
	}

	private void selectCommand()
	{
		index--;
		if (index < 0)
		{
			index = 0;
		}
		if (checkInput.getPreviousCommands.Count > 0)
		{
			inputField.text = checkInput.getPreviousCommands [index];
		}
		return;
	}
}
