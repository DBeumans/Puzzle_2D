public class DisconnectCommand : CommandBehaviour 
{
	public override void Run(string[] arguments)
	{
		if (users.User == null)
		{
			output.addText ("You are not connected to a server yet!", false);
			return;
		}
			
		users.User = null;
		output.addText ("Disconnected from current server.", false);
		return;
	}
}
