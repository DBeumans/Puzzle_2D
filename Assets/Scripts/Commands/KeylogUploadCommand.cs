using System.Collections;
using UnityEngine;

public class KeylogUploadCommand : CommandBehaviour 
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
            output.addText ("Keylogger failed: This command requires an IP as argument.", false);
			return;
		}

        terminalInputField.enabled = false;
        output.addText("Uploading keylogger... Please wait " + this.loadTime + " Seconds", false);
        StartCoroutine(load(arguments));
	}

    protected override IEnumerator load(object[] arguments)
    {
        var ip = arguments [1].ToString();
        yield return new WaitForSeconds(this.loadTime);

        if (loggerExists)
        {
            output.addText ("Keylogger failed: Another instance of the keylogger is already running.", false);
            this.done();
            yield break;
        }

        if (serversInSession.CurrentServer == null)
        {
            output.addText ("Keylogger failed: You need to be connected to the server before you can upload to the server: " + ip, false);
            loggerExists = false;
            this.done();
            yield break;
        }

        if (serversInSession.CurrentServer.IP != ip)
        {
            output.addText ("Keylogger failed: You need to be connected to the server before you can upload to the server: " + ip, false);
            loggerExists = false;
            this.done();
            yield break;
        }

        loggerExists = true;
        output.addText ("Successfully uploaded keylogger to server!" ,false);

        this.done();
    }
}
