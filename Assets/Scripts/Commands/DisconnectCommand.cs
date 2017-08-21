using System.Collections;

using UnityEngine;

public class DisconnectCommand : CommandBehaviour 
{
	public override void Run(string[] arguments)
	{
        if (serversInSession.ConnectedServer == null)
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
        output.addText ("Disconnecting from " + serversInSession.ConnectedServer.IP + "... Please wait for " + GameValues.LoadTime + " Seconds.", false);
        yield return new WaitForSeconds(GameValues.LoadTime);

        serversInSession.ConnectedServer = null;
        output.addText ("Disconnected from current server.", false);
        this.done();
    }
}
