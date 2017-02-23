using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FetchTerminalInput : MonoBehaviour 
{
	[SerializeField]private InputField inputField;
	private CheckTerminalInput checkInput;
	private ShowOutput output;
	private ScrollLogic scroll;
	private AutoComplete autocomplete;
	private int index;

	private void Start()
	{
		checkInput = GetComponent<CheckTerminalInput> ();
		output = GetComponent<ShowOutput> ();
		scroll = GetComponent<ScrollLogic> ();
		autocomplete = new AutoComplete ();
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
			scroll.updateWindow ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			selectCommand (-1);
		}

		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			selectCommand (1);
		}

		if (Input.GetKeyDown (KeyCode.Tab))
		{
			setWord ();
		}
	}

	private void setWord()
	{
		string value = autocomplete.scan (inputField.text);
		if (!string.IsNullOrEmpty (value))
		{
			inputField.text = value;
			resetCaret ();
		}
	}

	private void resetInput()
	{
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
		inputField.OnPointerClick(new PointerEventData(EventSystem.current));
		index = checkInput.getPreviousCommands.Count;
	}

	private void resetCaret()
	{
		inputField.caretPosition = inputField.text.Length;
	}

	private void selectCommand(int value)
	{
		index+= value;
		if (index < 0)
		{
			index = 0;
		}
		if (index > checkInput.getPreviousCommands.Count - 1)
		{
			index = checkInput.getPreviousCommands.Count - 1; 
		}

		if (checkInput.getPreviousCommands.Count > 0)
		{
			inputField.text = checkInput.getPreviousCommands [index];
		}
		resetCaret ();
	}
}
