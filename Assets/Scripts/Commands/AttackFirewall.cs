using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFirewall : MonoBehaviour 
{
	private User serverToAttack;
	private CreateWall wall;
	private FetchTerminalInput input;
	[SerializeField]private GameObject attackGame;
	private void Start()
	{
		wall = GetComponent<CreateWall> ();
		input = GetComponent<FetchTerminalInput> ();
	}
	public string attack(string ipAdress)
	{
		foreach (User server in CurrentUsers.getUsers)
		{
			if (server.getIp == ipAdress)
			{
				if (server.getFirewall)
				{
					serverToAttack = server;
					GameObject window;
					if (window = Instantiate (attackGame, attackGame.transform.position, Quaternion.identity) as GameObject)
					{
						input.enableInput (false);

						return wall.createWall (window, ipAdress);	
					}
					return "Failed to initialize attack.exe, please try again later.";
				}
			}
		}
		return "Could not reach the firewall of server: '"+ipAdress+"'! Please try again with a valid IPadress";
	}
}
