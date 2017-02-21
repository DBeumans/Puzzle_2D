using System.Collections;
using UnityEngine;

public class User
{
	private string name;
	public string getName{get{return name;}}
	private string ip;
	public string getIp{get{return ip;}}
	private bool firewall;
	public bool getFirewall{get{return firewall;}}

	private string[] files;
	public string[] getFiles{get{return files;}}

	public User(string name, string ip, bool firewall)
	{
		this.name = name;
		this.ip = ip;
		this.firewall = firewall;
		files = new string[2];
		createFolders ();
	}

	private void createFolders()
	{
		files[0] = "save.py";
		files[1] = "tjoepMachine.txt";
	}
}
