public class ConnectCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an IP adress as argument", false);
			return;
		}

		var ip = arguments [1];
        var servers = users.getUsers;
        for (var i = 0; i < servers.Count; i++)
        {
            if (servers[i].IP != ip)
                continue;

            if (servers[i].Firewall)
                continue;

            users.User = servers[i];
            output.addText ("Connected to '" + servers[i].Name + "' with IP '" + ip + "'", false);
            return;
        }

		output.addText ("Could not connect to '" + ip + "'", false);
		return;
	}
}
