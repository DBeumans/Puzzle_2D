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
		if (ConnectToComputer.getUser == null)
		{
			output += fileNotFound (function);
			return output;
		} 

		string response = "";
		switch (function)
		{
			case "save":
				response += SaveValues.Save ();
				response += PackageObjects.SaveGame ();
				output += response; 
			break;

			case "load":
				response += LoadValues.Load ();
				response += UnpackageObjects.LoadGame();
				output += response;
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
