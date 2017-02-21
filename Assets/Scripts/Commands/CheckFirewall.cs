using System.Collections;
using UnityEngine;

public class CheckFirewall
{
	public static string scan(string ip)
	{
		foreach(User test in CurrentUsers.getUsers)
		{
			if (test.getIp == ip)
			{
				if (test.getFirewall)
				{
					return "The server with ip: '" + ip + "' does have an active firewall!";
				} 
				else
				{
					return "The server with ip: '" + ip + "' does not have an active firewall!";
				}
			}
		}
		return "Could not connect to " + ip;
	}
}
