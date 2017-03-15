using UnityEngine;

public class AttackFirewallCommand : CommandBehaviour
{
	private CreateWall wall;
	private FetchTerminalInput input;
	private GameObject minigame;
	private CurrentUsers users;

	protected override void Start()
	{
		base.Start ();
		minigame = Resources.Load (Paths.firewallMinigame) as GameObject;
		if (minigame == null)
		{
			throw new System.Exception (Errormessage.resourceNull);
		}

		wall = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CreateWall> ();
		input = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<FetchTerminalInput> ();
		users = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CurrentUsers> ();
	}
		
	public override void Run(string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an IP adress as argument", false);
			return;
		}

		var ip = arguments [1];
		foreach (User server in users.getUsers)
		{
			if (server.getIp != ip)
			{
				continue;
			}

			if (!server.getFirewall)
			{
				continue;
			}

			foreach (User check in users.getUsers)
			{
				if (check.getIp == ip)
				{
					GameObject window;
					if (!(window = Instantiate (minigame, minigame.transform.position, Quaternion.identity) as GameObject))
					{
						output.addText ("Failed to initialize attack.exe, please try again later.", false);
						return;
					}

					input.enableInput (false);
					wall.createWall (window, check);
					return;
				}
			}

			output.addText ("Could not connect to: " + ip, false);
			return;
		}
		output.addText ("Could not attack '"+ip+"'. Please use an valid IP that has an active firewall.", false);
		return;
	}
}

