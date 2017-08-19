using UnityEngine;
using System.Collections.Generic;

public class AutoComplete
{
	private KeyWords keywords;

	public AutoComplete()
	{
		keywords = GameObject.FindGameObjectWithTag ("GameController").GetComponent<KeyWords>();
	}

	public List<string> scan (string value) 
	{
		if (string.IsNullOrEmpty(value)) 
		{
			return null;
		}
	
		List<string> found = keywords.Keywords.FindAll(w => w.StartsWith(value) );
		if (found.Count == 0)
		{
			return null;
		}

		return found;
	}
} 