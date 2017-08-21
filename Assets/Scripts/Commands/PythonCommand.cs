using UnityEngine;

public class PythonCommand : CommandBehaviour 
{
	private SaveValues saveValues;
	private LoadValues loadValues;

	protected override void Start()
	{
		base.Start ();
        saveValues = GameObject.FindGameObjectWithTag(Tags.saveManager).GetComponent<SaveValues> ();
        loadValues = GameObject.FindGameObjectWithTag(Tags.saveManager).GetComponent<LoadValues> ();
	}

	public override void Run (string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires a .py file as argument",false);
			return;
		}

        if (serversInSession.ConnectedServer == null)
		{
			output.addText(Errormessage.pythonNull, false);
			return;
		} 

		string[] file = arguments [1].Split (new string[]{".py"}, System.StringSplitOptions.None);
		switch (file[0])
		{
			case "save":
			output.addText(saveValues.Save (), false);
			break;

			case "load":
			output.addText(loadValues.load (), false);
			break;

			default:
			output.addText(Errormessage.pythonNull, false);
			break;
		}
		return;
	}
}
