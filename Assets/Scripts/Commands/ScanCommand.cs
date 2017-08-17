using System.Collections;
using UnityEngine;

public class ScanCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
        terminalInputField.enabled = false;
        StartCoroutine (load(null));
	}

    protected override IEnumerator load (object[] arguments)
	{
        var servers = users.getUsers;
		var response = "";
		output.addText ("Scanning for servers, please wait...",false);
		yield return new WaitForSeconds (this.loadTime/4);
		output.addText (".",false);
		yield return new WaitForSeconds (this.loadTime/4);
		output.addText ("..",false);
		yield return new WaitForSeconds (this.loadTime/4);
		output.addText ("...",false);
		yield return new WaitForSeconds (this.loadTime/4);

        for (var i = 0; i < servers.Count; i++)
            response += servers[i].Name + ": " + servers[i].IP + "\n";
		response += "Finished searching for servers.";
		output.addText (response, false);
        if(this.OnDone != null)
            this.OnDone();
	}
}
