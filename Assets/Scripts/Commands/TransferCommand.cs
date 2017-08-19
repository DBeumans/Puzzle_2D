using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferCommand : CommandBehaviour 
{
    private Money money;

    protected override void Start()
    {
        base.Start();
        money = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Money>();
    }

	public override void Run (string[] arguments)
	{
        if (arguments.Length != 4)
        {
            output.addText ("This command needs three arguments. Please type 'help' to get information about this command",false);
            return;
        }

        terminalInputField.enabled = false;
        output.addText("Checking transfer values... Please wait " + this.loadTime + " Seconds", false);
        StartCoroutine(load(arguments));
	}

    protected override IEnumerator load(object[] arguments)
    {
        var firstArg = arguments[1].ToString();
        var secondArg = arguments[2].ToString();
        var thirdArg = arguments[3].ToString();
        var amount = 0;

        yield return new WaitForSeconds(this.loadTime);
        if (!int.TryParse (firstArg, out amount))
        {
            output.addText ("Invalid argument. Please type 'help' to get information about this command", false);
            this.done();
            yield break;
        }

        var bankAccount = "";
        var code = "";

        var servers = serversInSession.Servers;
        for (var i = 0; i < servers.Count; i++)
        {
            if(servers[i].Username == secondArg)
                bankAccount = secondArg;
            if(servers[i].Code == thirdArg)
                code = thirdArg;
        }

        if (string.IsNullOrEmpty (bankAccount) || string.IsNullOrEmpty (code))
        {
            output.addText ("Could not connect to the account.", false);
            this.done();
            yield break;
        }

        float newLoadTime = this.loadTime * 15;
        output.addText("Connected to " + bankAccount + "!\nTransfereing $" + amount + "... Please wait " + newLoadTime + " Seconds", false);
        yield return new WaitForSeconds(newLoadTime);

        output.addText ("Successfully transfered $" + amount, false);
        money.addMoney(amount);
        this.done();
    }
}
