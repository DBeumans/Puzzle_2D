using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSegments
{
	public static string showContents()
	{
		if (ConnectToComputer.getUser != null)
		{
			string temp = "";
			for (int i = 0; i < ConnectToComputer.getUser.getFiles.Length; i++)
			{
				temp += (ConnectToComputer.getUser.getFiles[i] + "\n");
			}
			return temp;
		}
		return "You are not connected to a user yet.";
	}
}
