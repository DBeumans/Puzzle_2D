public class lsCommand : CommandBehaviour
{
	public override void Run(string[] arguments)
	{
		if (arguments.Length != 1)
		{
			output.addText ("This command does not accept any arguments.", false);
			return;
		}

		if (users.User == null)
		{
			output.addText ("You are not connected to a server yet!", false);
			return;
		}

		string files = "";
		for (int i = 0; i < users.User.getFiles.Length; i++)
		{
			files += (users.User.getFiles[i] + "\n");
		}
		output.addText (files, false);
		return;
	}
}
