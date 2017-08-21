using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ServersInSession : MonoBehaviour 
{
	private List<Server> servers;
    public List<Server> Servers{get{return servers;}}

    private Server connectedServer;
    public Server ConnectedServer{get{return connectedServer;} set{connectedServer = value;}}

    [SerializeField]private Server personalServer;
    public Server PersonalServer{get{return personalServer;}}

    [SerializeField]private int maxAmountOfServers;
    private Money money;

	private void Start()
	{
        connectedServer = null;
        money = FindObjectOfType<Money>();
		createUsers ();
        createPersonalServer();
	}

	private void createUsers()
	{
        servers = new List<Server> ();
        for(var i = 0; i < maxAmountOfServers; i++)
            servers.Add (new Server());
	}

    private void createPersonalServer()
    {
        personalServer = new Server(GameValues.Money);
        money.setPlayerInfo(personalServer);
    }
}
