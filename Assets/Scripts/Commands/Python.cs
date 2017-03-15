using System.Collections;
using UnityEngine;

public class Python : MonoBehaviour
{
	private SaveValues saveValues;
	private LoadValues loadValues;
	private CurrentUsers users;

	private void Start()
	{
		saveValues = GetComponent<SaveValues> ();
		loadValues = GetComponent<LoadValues> ();
		users = GetComponent<CurrentUsers> ();
	}

	public string pythonFunction(string function)
	{
		string output = "";
		if (users.User == null)
		{
			output += fileNotFound (function);
			return output;
		} 

		switch (function)
		{
			case "save":
				output += saveValues.Save ();
				output += output; 
			break;

			case "load":
				output += loadValues.load ();
				output += output;
			break;

			default:
				output += fileNotFound (function);
			break;
		}
		return output;
	}

	private string fileNotFound(string filename)
	{
		return "Could not find '" +filename+ ".py'. Are you sure that file exists?";
	}
}
