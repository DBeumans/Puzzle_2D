public class lsCommand : CommandBehaviour
{
	public override void Run(string[] arguments)
	{
		if (arguments.Length != 1)
		{
			output.addText ("This command does not accept any arguments.", false);
			return;
		}

        if (serversInSession.ConnectedServer == null)
		{
			output.addText ("You are not connected to a server yet!", false);
			return;
		}

        var fileNames = "";
        var files = serversInSession.ConnectedServer.Files;
       
        for (int i = 0; i < files.Length; i++)
            fileNames += (files[i] + "\n");

		output.addText (fileNames, false);
		return;
	}
}
