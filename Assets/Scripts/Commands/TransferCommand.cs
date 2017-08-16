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
        print(money);
    }

	public override void Run (string[] arguments)
	{
		if (arguments.Length != 4)
		{
			output.addText ("This command needs three arguments. Please type 'help' to get information about this command",false);
			return;
		}

		var amount = 0;
		if (!int.TryParse (arguments [1], out amount))
		{
			output.addText ("Invalid argument. Please type 'help' to get information about this command", false);
			return;
		}

		var bankAccount = "";
		var code = "";

        var servers = users.getUsers;
        for (var i = 0; i < servers.Count; i++)
        {
            if(servers[i].Username == arguments[2])
                bankAccount = arguments[2];
            if(servers[i].Code == arguments[3])
                code = arguments[3];
            
        }

		if (string.IsNullOrEmpty (bankAccount) || string.IsNullOrEmpty (code))
		{
			output.addText ("Could not connect to the account.", false);
			return;
		}

		output.addText ("transfering: $"+amount+" from the account: "+bankAccount+ " with secret code: " + code, false);
        money.addMoney(amount);
		return;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            money.addMoney(100);
    }
}
