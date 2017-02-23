using UnityEngine;
using System.Collections.Generic;

public class AutoComplete
{
	private KeyWords keywords;
	private string textValue;

	public AutoComplete()
	{
		keywords = GameObject.FindGameObjectWithTag ("GameController").GetComponent<KeyWords>();
		textValue = "";
	}

	public string scan (string value) 
	{
		string oldString = textValue;
		textValue = value;

		if (!string.IsNullOrEmpty(value) && value.Length != oldString.Length) 
		{
			List<string> found = keywords.GetKeywords.FindAll(w => w.StartsWith(value) );
			if (found.Count > 0)
			{
				textValue = found [0];
				return found[0];
			}
		}
		return null;
	}
} 