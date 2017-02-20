using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowOutput : MonoBehaviour 
{
	[SerializeField]private Text outputText;

	public void addText(string textToShow, bool showUsername)
	{
		string output = (textToShow + "\n");
		if (showUsername)
		{
			outputText.text += ("danivdwerf$ ");
		}
		outputText.text += output;
	}

	public void clear()
	{
		outputText.text = "";
	}
}
