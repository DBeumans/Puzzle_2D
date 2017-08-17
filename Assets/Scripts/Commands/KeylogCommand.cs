using System.Collections;

public class KeylogCommand : CommandBehaviour 
{
	private bool loggerExists;
	public bool LoggerExists{get{return loggerExists;} set{loggerExists = value;}}

	protected override void Start()
	{
		base.Start ();
		loggerExists = false;
	}

	public override void Run(string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an IP as argument.", false);
			return;
		}

		if (loggerExists)
		{
			output.addText ("Another instance of the keylogger is already running, please use 'stopKeylogger' to stop the current instance.", false);
			return;
		}

        terminalInputField.enabled = false;
		var ip = arguments [1];
		loggerExists = true;
		output.addText("Successfully instantiated the keylogger!\nUploading keylogger to server, please wait...", false);
		upload (ip);
        terminalInputField.enabled = true;
		return;
	}

	private void upload(string ipAdress)
	{
		if (!loggerExists)
		{
			output.addText ( "Failed to upload keylogger, please try again later.", false);
            loggerExists = true;
			return;
		}	

		if (users.User == null)
		{
			output.addText ("You are not connected to any server, please use 'connect [IPadress]' to connect to a server.", false);
			loggerExists = false;
			return;
		}

        if (users.User.IP != ipAdress)
		{
			output.addText ("Could not connect to: " + ipAdress, false);
			loggerExists = false;
			return;
		}

		output.addText ("Successfully uploaded keylogger to server." ,false);
		return;
	}
}
