using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUsers : MonoBehaviour 
{
	private static List<User> usersInSession;
	public static List<User> getUsers{get{return usersInSession;}}
	private List<User> users;
	private KeyWords keywords;
	private int maxUsers;

	private void Awake()
	{
		maxUsers = 3;
		keywords = GetComponent<KeyWords> ();
		createUsers ();
		setCurrentUsers ();
	}

	private void createUsers()
	{
		users = new List<User> ();
		for(int i = 0; i < 10; i++)
		{
			users.Add (new User());
			keywords.addKeyword (users[i].getIp);
			keywords.addKeyword (users[i].getName);
		}
	}

	private void setCurrentUsers()
	{
		usersInSession = new List<User> ();
		for (int i = 0; i < maxUsers; i++)
		{
			int index = Random.Range (0, users.Count - 1);
			usersInSession.Add(users[index]);
			users.RemoveAt (index);
		}
	}
}
