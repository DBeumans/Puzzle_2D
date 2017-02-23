using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFirewall : MonoBehaviour 
{
	private User serverToAttack;

	public string attack(string ipAdress)
	{
		foreach (User server in CurrentUsers.getUsers)
		{
			if (server.getIp == ipAdress)
			{
				if (server.getFirewall)
				{
					serverToAttack = server;
					return "Successfully connected to the firewall! Initializing attack, please wait...";
				}
			}
		}
		return "Could not reach the firewall of server: '"+ipAdress+"'! Please try again with a valid IPadress";
	}
}
