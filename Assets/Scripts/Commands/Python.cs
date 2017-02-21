using System.Collections;
using UnityEngine;

public class Python : MonoBehaviour
{
	private SaveProperties saveLogic;

	private void Start()
	{
		saveLogic = GetComponent<SaveProperties> ();
	}

	public string pythonFunction(string function)
	{
		string output = "";
		switch (function)
		{
			case "save":
				saveLogic.Save ();
				output += "Saved!"; 
			break;
		}
		return output;
	}
}
