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
        output.addText ("Starting keylogger... Please Wait " + this.loadTime + " Seconds", false);
        StartCoroutine (load(arguments));
		return;
	}

    protected override IEnumerator load(object[] arguments)
    {
        string[] logItems = {
            "\n" + serversInSession.CurrentServer.Bank + "{return}\n{tab}\n" + serversInSession.CurrentServer.Username + "{return}\n" + serversInSession.CurrentServer.Password + "{return}\n",
            "\nwww.Vyves.nl{return}\n{tab}\nJohn Doe{return}\nMonsterCock123{return}\n"
        };

        //"\nwww.prello.com{return}\n{tab}\npropture{return}\nCompanyName31{return}\n",
        //"\nwww.headnotes.com{return}\n{tab}\nJohn Doe{return}\nAmsterdam191{return}\n",
        //"\nwww.offline.com{return}\n{tab}\n" + ConnectToComputer.getUser.getName + "{return}\nDirtyProstate16{return}\n",

        yield return new WaitForSeconds(this.loadTime);

        if (!logger.LoggerExists)
        {
            output.addText("No instance of the keylogger found.", false);
            this.done();
            yield break;
        }

        var log = "";
        for (var i = 0; i < amountOfLogs; i++)
            log += logItems[Random.Range(0, logItems.Length - 1)]; 

        float newLoadTime = this.loadTime * 15;
        output.addText("Successfully started keylogger! Logs will be printed on the 'Keylogs-Results' tab in your browser in " + newLoadTime + " Seconds", false);
        ui.updateResults(log, newLoadTime);
        this.done();
    }
}
