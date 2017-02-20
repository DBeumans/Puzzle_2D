using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerminalInput : MonoBehaviour 
{
	private ShowOutput output;
	private ScanLogic scan;
	private CheckFirewall firewall;
	private ConnectToComputer connect;
	private void Start()
	{
		output = GetComponent<ShowOutput> ();
		scan = GetComponent<ScanLogic> ();
		firewall = GetComponent<CheckFirewall> ();
		connect = GetComponent<ConnectToComputer> ();
	}

	public void checkInput(string input)
	{
		string[] arguments = input.Split (new string[]{" "}, System.StringSplitOptions.None);

		switch (arguments [0])
		{
			case "help":
				output.addText ("type 'scan' to scan for nearby ip adresses.\ntype 'checkForFirewall [IP adress]' to check if the adress has a firewall.\ntype 'clear' to clear the terminal.", false);
			break;

			case "scan":
				string test = scan.scan ();
				output.addText(test,false);
			break;

			case "checkForFirewall":
				output.addText(firewall.scan (arguments[1]), false);
			break;

			case "tjoep":
				output.addText ("PATS!", false);
			break;

			case "clear":
				output.clear ();
			break;

			case "connect":
				output.addText (connect.connectToUser(arguments[1]), false);
			break;

			case "disconnect":
				output.addText (connect.disconnectFromUser(), false);
			break;

			default:
				output.addText ("-bash: " + input + ": command not found",false);
			break;
		}
	}
}
