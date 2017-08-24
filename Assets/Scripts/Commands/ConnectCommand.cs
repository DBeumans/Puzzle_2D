using System.Collections;

using UnityEngine;

public class ConnectCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an IP adress as argument", false);
			return;
		}

        terminalInputField.enabled = false;
        output.addText("Connecting... please wait: " + GameValues.LoadTime + " seconds", false);
        StartCoroutine(load(arguments));
		return;
	}

    protected override IEnumerator load(object[] arguments)
    {
        var ip = arguments[1].ToString();
        var servers = serversInSession.Servers;
        yield return new WaitForSeconds(GameValues.LoadTime);
        for (var i = 0; i < servers.Count; i++)
        {
            if (servers[i].IP != ip)
                continue;

            if (servers[i].Firewall)
                continue;

            serversInSession.ConnectedServer = servers[i];
            output.addText ("Connected to '" + servers[i].Name + "' with IP '" + ip + "'", false);
            this.done();
            yield break;
        }

        output.addText ("Could not connect to '" + ip + "'", false);
        this.done();
    }
}
