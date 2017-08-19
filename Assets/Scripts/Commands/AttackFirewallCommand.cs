using UnityEngine;
using System.Collections;

public class AttackFirewallCommand : CommandBehaviour
{
    private FireWall wall;
	private FetchTerminalInput input;

	private GameObject minigame;

	protected override void Start()
	{
		base.Start ();
		minigame = Resources.Load (Paths.firewallMinigame) as GameObject;
		if (minigame == null)
			throw new System.Exception (Errormessage.resourceNull);

        wall = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<FireWall> ();
		input = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<FetchTerminalInput> ();
	}
		
	public override void Run(string[] arguments)
	{
		if (arguments.Length != 2)
		{
			output.addText ("This command requires an IP adress as argument", false);
			return;
		}

        this.terminalInputField.enabled = false;
        output.addText("Initializing attacking software... Please wait " + this.loadTime + " Seconds", false);
        StartCoroutine(load(arguments));
	}

    protected override IEnumerator load(object[] arguments)
    {
        var ip = arguments [1].ToString();
        var servers = users.getUsers;

        yield return new WaitForSeconds(this.loadTime);

        for (var i = 0; i < servers.Count; i++)
        {
            if (servers[i].IP != ip)
                continue;

            if (!servers[i].Firewall)
                continue;  
            
            GameObject window;
            if (!(window = Instantiate (minigame, minigame.transform.position, Quaternion.identity) as GameObject))
            {
                output.addText ("Failed to initialize attack.exe, please try again later.", false);
                this.done();
                yield break;
            }

            input.enableInput (false);
            wall.create(window, servers[i]);
            this.done();
            yield break;

        }

        output.addText ("Could not attack '" + ip + "'. Please use a valid IP that has an active firewall.", false);
        this.done();
    }
}

