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
		foreach(User check in users.getUsers)
		{
			if (check.getIp == ip && !check.getFirewall)
			{
				users.User = check;
				output.addText ("Connected to '"+check.getName+"' with IP '"+ip+"'", false);
				return;
			}
		}
		output.addText ("Could not connect to '"+ip+"'", false);
		return;
	}
}
