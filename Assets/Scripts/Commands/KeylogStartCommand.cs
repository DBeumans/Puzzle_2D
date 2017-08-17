using System.Collections;
using UnityEngine;

public class KeylogStartCommand : CommandBehaviour 
{
	private KeylogCommand logger;

	[Range(1f,300f)]
	[SerializeField]private int loggingDuration;

	[SerializeField]private int amountOfLogs;

	private KeyloggerUI ui;

	protected override void Start()
	{
		base.Start ();
		logger = GetComponent<KeylogCommand> ();
		ui = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<KeyloggerUI> ();
	}

	public override void Run(string[] arguments)
	{
		if (!logger.LoggerExists)
		{
			output.addText ("No instance of the keylogger found, please use 'instantiateKeylogger' to create an instance of the logger.", false);
			return;
		}

		StartCoroutine ("logStart");
		output.addText ("Successfully started the keylogger.\nYour logs will be send to the the 'Keylog-Results' site in your Xplorer.", false);
		return;
	}

	private IEnumerator logStart()
    {
        terminalInputField.enabled = false;
        string[] logItems = {
            //"\nwww.prello.com{return}\n{tab}\npropture{return}\nCompanyName31{return}\n",
            "\n"+users.User.Bank+"{return}\n{tab}\n" + users.User.Username + "{return}\n" + users.User.Password + "{return}\n",
            //"\nwww.headnotes.com{return}\n{tab}\nJohn Doe{return}\nAmsterdam191{return}\n",
            //"\nwww.offline.com{return}\n{tab}\n" + ConnectToComputer.getUser.getName + "{return}\nDirtyProstate16{return}\n",
            "\nwww.Vyves.nl{return}\n{tab}\nJohn Doe{return}\nMonsterCock123{return}\n"
        };
		yield return new WaitForSeconds (loggingDuration);

		var log = "";
		for(var i = 0; i < amountOfLogs; i++)
			log += logItems[Random.Range(0, logItems.Length-1)]; 

		ui.updateResults (log);
		stoplogger ();
        terminalInputField.enabled = true;
	}

	private void stoplogger()
	{
		if (logger.LoggerExists)
		{
			logger.LoggerExists = false;
			StopCoroutine ("logStart");
			output.addText ("Keylogger sucessfully started or has been cancelled manually.", false);
			return;
		}

		output.addText ("Can't stop keylogger since there is no active instance of the keylogger.", false);
		return;
	}
}
