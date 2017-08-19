using System.Collections;

using UnityEngine;

public class DisconnectCommand : CommandBehaviour 
{
	public override void Run(string[] arguments)
	{
        if (serversInSession.CurrentServer == null)
		{
			output.addText ("You are not connected to a server yet!", false);
			return;
		}

        if (arguments.Length > 1)
        {
            output.addText("This command does not take any arguments. Use 'help' to see more information about the command.", false);
            return;
        }
		
        StartCoroutine(load(arguments));
		return;
	}

    protected override IEnumerator load(object[] arguments)
    {
        this.terminalInputField.enabled = false;
        output.addText ("Disconnecting from " + serversInSession.CurrentServer.IP + "... Please wait for " + this.loadTime + " Seconds.", false);
        yield return new WaitForSeconds(this.loadTime);

        serversInSession.CurrentServer = null;
        output.addText ("Disconnected from current server.", false);
        this.done();
    }
}
