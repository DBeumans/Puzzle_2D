using System.Collections;
using UnityEngine;

public class ScanCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
		StartCoroutine ("load");
	}

	protected override IEnumerator load ()
	{
		string response = "";
		output.addText ("Scanning for servers, please wait...",false);
		yield return new WaitForSeconds (this.loadTime/4);
		output.addText (".",false);
		yield return new WaitForSeconds (this.loadTime/4);
		output.addText ("..",false);
		yield return new WaitForSeconds (this.loadTime/4);
		output.addText ("...",false);
		yield return new WaitForSeconds (this.loadTime/4);

		for(int i = 0; i < users.getUsers.Count; i++)
		{
			response += users.getUsers[i].getName + ": " + users.getUsers[i].getIp + "\n";
		}
		response +="Finished searching for servers.";
		output.addText (response, false);
	}
}
