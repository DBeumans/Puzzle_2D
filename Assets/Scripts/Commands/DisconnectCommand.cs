using System.Collections;

using UnityEngine;

public class DisconnectCommand : CommandBehaviour 
{
	public override void Run(string[] arguments)
	{
		if (users.User == null)
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
        output.addText ("Disconnecting from " + users.User.IP + "... Please wait for " + this.loadTime + " Seconds.", false);
        yield return new WaitForSeconds(this.loadTime);

        users.User = null;
        output.addText ("Disconnected from current server.", false);
        if (this.OnDone != null)
            this.OnDone();
    }
}
