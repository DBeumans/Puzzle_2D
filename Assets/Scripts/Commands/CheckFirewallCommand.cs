using UnityEngine;

using System.Collections;

public class CheckFirewallCommand : CommandBehaviour
{
	public override void Run (string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an ip as argument.", false);
			return;
		}

        this.terminalInputField.enabled = false;
        output.addText("Checking for firewall on: " + arguments[1] + "... Please wait " + GameValues.LoadTime + " Seconds", false);
        StartCoroutine(load(arguments));
	}

    protected override IEnumerator load(object[] arguments)
    {
        var ip = arguments [1].ToString();
        var servers = serversInSession.Servers;

        yield return new WaitForSeconds(GameValues.LoadTime);

        for(var i = 0; i < servers.Count; i++)
        {
            if (servers[i].IP != ip)
                continue;

            if (servers[i].Firewall)
            {
                output.addText("The server with ip: '" + ip + "' has an active firewall!", false);
                this.done();
                yield break;
            }

            output.addText("The server with ip: '" + ip + "' does not have an active firewall!", false);
            this.done();
            yield break;
        }
    }
}
