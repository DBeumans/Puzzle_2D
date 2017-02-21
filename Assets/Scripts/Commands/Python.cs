using System.Collections;
using UnityEngine;

public class Python : MonoBehaviour
{
	private SaveProperties saveLogic;
	string output;

	private void Start()
	{
		saveLogic = GetComponent<SaveProperties> ();
		output = "";
	}

	public string pythonFunction(string function)
	{
		
		switch (function)
		{
			case "save":
				saveLogic.Save ();
				output += "Saved your session!"; 
			break;
		}
		return output;
	}
}
