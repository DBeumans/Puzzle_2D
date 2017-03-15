using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUsers : MonoBehaviour 
{
	private List<User> usersInSession;
	public List<User> getUsers{get{return usersInSession;}}

	private User connectedUser;
	public User User{get{return connectedUser;}set{connectedUser = value;}}

	private int maxUsers;

	private void Awake()
	{
		maxUsers = 3;
		connectedUser = null;
		createUsers ();
	}

	private void createUsers()
	{
		usersInSession = new List<User> ();
		for(int i = 0; i < maxUsers; i++)
		{
			usersInSession.Add (new User());
		}
	}
}
