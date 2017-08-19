using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ServersInSession : MonoBehaviour 
{
	private List<Server> servers;
    public List<Server> Servers{get{return servers;}}

	private Server currentServer;
    public Server CurrentServer{get{return currentServer;} set{currentServer = value;}}

    [SerializeField]private int maxAmountOfServers;

	private void Awake()
	{
        currentServer = null;
		createUsers ();
	}

	private void createUsers()
	{
        servers = new List<Server> ();
        for(var i = 0; i < maxAmountOfServers; i++)
            servers.Add (new Server());
	}
}
