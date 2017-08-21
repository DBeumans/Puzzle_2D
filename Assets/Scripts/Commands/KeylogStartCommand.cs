using System.Collections;
using UnityEngine;

public class KeylogStartCommand : CommandBehaviour 
{
    [SerializeField]private int amountOfLogs;

    private KeylogUploadCommand logger;
	private KeyloggerUI ui;

	protected override void Start()
	{
		base.Start ();
        logger = GetComponent<KeylogUploadCommand> ();
		ui = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<KeyloggerUI> ();
	}

	public override void Run(string[] arguments)
	{
        terminalInputField.enabled = false;
        output.addText ("Starting keylogger... Please Wait " + GameValues.LoadTime + " Seconds", false);
        StartCoroutine (load(arguments));
		return;
	}

    protected override IEnumerator load(object[] arguments)
    {
        string[] logItems = {
            "\n" + serversInSession.ConnectedServer.Bank + "{return}\n{tab}\n" + serversInSession.ConnectedServer.Username + "{return}\n" + serversInSession.ConnectedServer.Password + "{return}\n",
            "\nwww.Vyves.nl{return}\n{tab}\nJohn Doe{return}\nMonsterCock123{return}\n"
        };

        //"\nwww.prello.com{return}\n{tab}\npropture{return}\nCompanyName31{return}\n",
        //"\nwww.headnotes.com{return}\n{tab}\nJohn Doe{return}\nAmsterdam191{return}\n",
        //"\nwww.offline.com{return}\n{tab}\n" + ConnectToComputer.getUser.getName + "{return}\nDirtyProstate16{return}\n",

        yield return new WaitForSeconds(GameValues.LoadTime);

        if (!logger.LoggerExists)
        {
            output.addText("No instance of the keylogger found.", false);
            this.done();
            yield break;
        }

        var log = "";
        for (var i = 0; i < amountOfLogs; i++)
            log += logItems[Random.Range(0, logItems.Length - 1)]; 
        
        output.addText("Successfully started keylogger! Logs will be printed on the 'Keylogs-Results' tab in your browser in " + GameValues.LongLoadTime + " Seconds", false);
        ui.updateResults(log, GameValues.LongLoadTime);
        this.done();
    }
}
