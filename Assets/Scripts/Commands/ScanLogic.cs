using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ScanLogic
{
	public static string scan()
	{
		string temp = "Servers in your neighbourhood:\n\n";
		for(int i = 0; i < CurrentUsers.getUsers.Count; i++)
		{
			temp += CurrentUsers.getUsers[i].getName + ": " + CurrentUsers.getUsers[i].getIp + "\n";
		}
		return temp;
	}
}
