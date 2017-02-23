using System.Collections;
using UnityEngine;

public class ConnectToComputer
{
	private static User connectedUser;
	public static User getUser{get{return connectedUser;}}

	public static string connectToUser(string ip)
	{
		foreach(User check in CurrentUsers.getUsers)
		{
			if (check.getIp == ip && !check.getFirewall)
			{
				connectedUser = check;
				return "Connected to '" + check.getName + "' with IP '" + ip + "'";
			}
		}
		return "Could not connect to '" + ip +"'";
	}

	public static string disconnectFromUser()
	{
		if (connectedUser != null)
		{
			connectedUser = null;
			return "Disconnected from current server.";
		}
		return "You are not connected to a server yet!";
	}
}
