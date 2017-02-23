using UnityEngine;
using System.Collections.Generic;

public class AutoComplete
{
	private List<string> keyWords = new List<string>();
	private string textValue;
	public AutoComplete()
	{
		keyWords.Add("scan");
		keyWords.Add("checkForFirewall");
		keyWords.Add("connect");
		keyWords.Add("ls");
		keyWords.Add("disconnect");
		keyWords.Add("clear");
		keyWords.Add ("tjoep");
		keyWords.Add("help");
		keyWords.Add("python");	
		textValue = "";
	}

	public string scan (string value) 
	{
		string oldString = textValue;
		textValue = value;

		if (!string.IsNullOrEmpty(value) && value.Length != oldString.Length) 
		{
			List<string> found = keyWords.FindAll(w => w.StartsWith(value) );
			if (found.Count > 0)
			{
				textValue = found [0];
				return found[0];
			}
		}
		return null;
	}
} 