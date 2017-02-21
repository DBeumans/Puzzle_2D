using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerminalInput : MonoBehaviour 
{
	private ShowOutput output;
	private Python python;

	private List<string> usedCommands;
	public List<string> getPreviousCommands{get{return usedCommands;}}
	private void Start()
	{
		output = GetComponent<ShowOutput> ();
		python = GetComponent<Python> ();
		usedCommands = new List<string> ();
	}

	public void checkInput(string input)
	{
		string[] arguments = input.Split (new string[]{" "}, System.StringSplitOptions.None);
		usedCommands.Add (input);

		switch (arguments [0])
		{
			case "help":
				output.addText ("type 'scan' to scan for nearby ip adresses.\ntype 'checkForFirewall [IP adress]' to check if the adress has a firewall.\ntype 'connect [IP adress] to connect to a computer without firewall\ntype 'disconnect' to disconnect from someone\ntype 'ls' while connected to someone to show the computer's contents\ntype 'python [filename.py]' to execute a python script\ntype 'clear' to clear the terminal.", false);
			break;

			case "scan":
			string scanResult = ScanLogic.scan ();
				output.addText(scanResult,false);
			break;

			case "checkForFirewall":
			if (arguments.Length > 1)
			{
				output.addText (CheckFirewall.scan (arguments [1]), false);
			} 
			else
			{
				noArgumentError ();
				break;
			}
			break;

			case "tjoep":
				output.addText ("PATS!", false);
			break;

			case "clear":
				output.clear ();
			break;

			case "connect":
			if (arguments.Length > 1)
			{
				output.addText (ConnectToComputer.connectToUser (arguments [1]), false);
			} 
			else
			{
				noArgumentError ();
				break;
			}
			break;

			case "disconnect":
				output.addText (ConnectToComputer.disconnectFromUser(), false);
			break;

			case "ls":
				output.addText (ListSegments.showContents(), false);
			break;

			case "python":
			if (arguments.Length <= 1)
			{
				noArgumentError ();
				break;
			}

			string[] pythonFile = arguments [1].Split (new string[]{ ".py" }, System.StringSplitOptions.None);
			if (pythonFile.Length > 1)
			{
				output.addText (python.pythonFunction (pythonFile [0]), false);
			} else
			{
				noArgumentError ();
				break;
			}
			break;

			default:
				output.addText ("-bash: " + input + ": command not found",false);
			break;
		}
	}

	private void noArgumentError()
	{
		output.addText ("This command requires an valid argument!", false);
	}
}
