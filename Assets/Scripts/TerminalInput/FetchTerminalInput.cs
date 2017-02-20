using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FetchTerminalInput : MonoBehaviour 
{
	[SerializeField]private InputField inputField;
	private CheckTerminalInput checkInput;
	private ShowOutput output;

	private void Start()
	{
		checkInput = GetComponent<CheckTerminalInput> ();
		output = GetComponent<ShowOutput> ();
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
	}

	private void resetInput()
	{
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
		inputField.OnPointerClick(new PointerEventData(EventSystem.current));
	}
}
