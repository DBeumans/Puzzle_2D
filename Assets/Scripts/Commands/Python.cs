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

		switch (function)
		{
			case "save":
				string saveResult = saveLogic.Save ();
				output += saveResult; 
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
