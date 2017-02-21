using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSegments : MonoBehaviour 
{
	private ConnectToComputer user;

	private void Start()
	{
		user = GetComponent<ConnectToComputer> ();	
	}

	public string showContents()
	{
		if (user.getUser != null)
		{
			string temp = "";
			for (int i = 0; i < user.getUser.getFiles.Length; i++)
			{
				temp += (user.getUser.getFiles[i] + "\n");
			}
			return temp;
		}
		return "You are not connected to a user yet.";
	}
}
