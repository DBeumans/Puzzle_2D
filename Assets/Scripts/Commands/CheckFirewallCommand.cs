public class CheckFirewallCommand : CommandBehaviour
{
	public override void Run (string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an ip as argument.", false);
			return;
		}

		var ip = arguments [1];
		foreach(User test in users.getUsers)
		{
			if (test.getIp == ip)
			{
				if (test.getFirewall)
				{
					output.addText("The server with ip: '" + ip + "' has an active firewall!", false);
					return;
				}
				else
				{
					output.addText("The server with ip: '" + ip + "' does not have an active firewall!", false);
					return;
				}
			}
		}
	}
}
