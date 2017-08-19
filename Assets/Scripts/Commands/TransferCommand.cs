using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
		if (arguments.Length != 4)
		{
			output.addText ("This command needs three arguments. Please type 'help' to get information about this command",false);
			return;
		}

		int amount = 0;
		if (!int.TryParse (arguments [1], out amount))
		{
			output.addText ("Invalid argument. Please type 'help' to get information about this command", false);
			return;
		}

		string bankAccount = "";
		string code = "";
	
		foreach (User user in users.getUsers)
		{
			if (user.Username == arguments[2])
			{
				bankAccount = arguments [2];
			}

			if (user.Code == arguments[3])
			{
				code = arguments [3];
			}

			//var max = (user.Money/100) * 5;
		}

		if (string.IsNullOrEmpty (bankAccount) || string.IsNullOrEmpty (code))
		{
			output.addText ("Could not connect to the account.", false);
			return;
		}
		output.addText ("transfering: $"+amount+" from the account: "+bankAccount+ " with secret code: " + code, false);
		return;
	}
}
