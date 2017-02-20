using System.Collections;
using UnityEngine;

public class ConnectToComputer : MonoBehaviour 
{
	private CurrentUsers users;
	[SerializeField]private User connectedUser;

	private void Start()
	{
		users = GetComponent<CurrentUsers> ();
	}

	public string connectToUser(string ip)
	{
		foreach(User check in users.getUsers)
		{
			if (check.getIp == ip && !check.getFirewall)
			{
				connectedUser = check;
				return "Connected to '" + check.getName + "' with IP '" + ip + "'";
			}
		}
		return "Could not connect to '" + ip +"'";
	}

	public string disconnectFromUser()
	{
		if (connectedUser != null)
		{
			connectedUser = null;
			return "Disconnected from current users";
		}
		return "You are not connected to anyone!";
	}
}
