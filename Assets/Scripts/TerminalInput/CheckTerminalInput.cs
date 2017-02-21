using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerminalInput : MonoBehaviour 
{
	private ShowOutput output;
	private ScanLogic scan;
	private CheckFirewall firewall;
	private ConnectToComputer connect;
	private ListSegments list;

	private List<string> usedCommands;
	public List<string> getPreviousCommands{get{return usedCommands;}}
	private void Start()
	{
		output = GetComponent<ShowOutput> ();
		scan = GetComponent<ScanLogic> ();
		firewall = GetComponent<CheckFirewall> ();
		connect = GetComponent<ConnectToComputer> ();
		list = GetComponent<ListSegments> ();

		usedCommands = new List<string> ();
	}

	public void checkInput(string input)
	{
		string[] arguments = input.Split (new string[]{" "}, System.StringSplitOptions.None);
		usedCommands.Add (input);

		switch (arguments [0])
		{
			case "help":
				output.addText ("type 'scan' to scan for nearby ip adresses.\ntype 'checkForFirewall [IP adress]' to check if the adress has a firewall.\ntype 'connect [IP adress] to connect to a computer without firewall\ntype 'disconnect' to disconnect from someone\ntype 'ls' while connected to someone to show the computer's contents\n'type 'clear' to clear the terminal.", false);
			break;

			case "scan":
				string scanResult = scan.scan ();
				output.addText(scanResult,false);
			break;

			case "checkForFirewall":
			if (arguments.Length > 1)
			{
				output.addText (firewall.scan (arguments [1]), false);
			} 
			else
			{
				noArgumentError ();
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
				output.addText (connect.connectToUser (arguments [1]), false);
			} 
			else
			{
				noArgumentError ();
			}
			break;

			case "disconnect":
				output.addText (connect.disconnectFromUser(), false);
			break;

			case "ls":
				output.addText (list.showContents(), false);
			break;

			case "python":
			string[] temp = arguments [1].Split (new string[]{ ".py" }, System.StringSplitOptions.None);
			if (temp.Length > 1)
			{
				print ("contains python");
			} 
			else
			{
				noArgumentError ();
			}
			break;

			case "attackFirewall":
			if (arguments.Length > 1)
			{
				//open minigame
			} 
			else
			{
				noArgumentError ();
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
