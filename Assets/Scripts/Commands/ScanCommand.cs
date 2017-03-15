public class ScanCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
		string response = "";
		for(int i = 0; i < users.getUsers.Count; i++)
		{
			response += users.getUsers[i].getName + ": " + users.getUsers[i].getIp + "\n";
		}
		output.addText (response, false);
	}
}
