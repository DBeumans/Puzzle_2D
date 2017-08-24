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
        var servers = serversInSession.Servers;
		var response = "";
        output.addText ("Scanning for servers... Please wait " + GameValues.LoadTime + " Seconds",false);
        yield return new WaitForSeconds(GameValues.LoadTime);

        for (var i = 0; i < servers.Count; i++)
            response += servers[i].Name + ": " + servers[i].IP + "\n";
		response += "Finished searching for servers.";
		output.addText (response, false);
        this.done();
	}
}
