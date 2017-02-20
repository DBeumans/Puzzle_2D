using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ScanLogic : MonoBehaviour 
{
	private CurrentUsers users;

	private void Start()
	{
		users = GetComponent<CurrentUsers> ();	
	}

	public string scan()
	{
		string temp = "IP adresses in your neighbourhood:\n\n";
		for(int i = 0; i < users.getUsers.Count; i++)
		{
			temp += users.getUsers[i].getName + ": " + users.getUsers[i].getIp + "\n";
		}
		return temp;
	}
}
