using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
	private string name;
	public string getName{get{return name;}}
	private string ip;
	public string getIp{get{return ip;}}
	private bool firewall;
	public bool getFirewall{get{return firewall;}}

	private Dictionary <string,List<string>> folderStructure;

	public User(string name, string ip, bool firewall)
	{
		this.name = name;
		this.ip = ip;
		this.firewall = firewall;
		folderStructure = new Dictionary<string,List<string>> ();
		createFolders ();
	}

	private void createFolders()
	{
		folderStructure.Add ("System/", new List<string>());
		folderStructure.Add ("Temp/", new List<string>());
		folderStructure.Add ("Documents/", new List<string>());
		folderStructure.Add ("Pictures/", new List<string>());
	}

	public List<string> getFolders()
	{
		List<string> folders = new List<string> ();
		foreach (KeyValuePair<string, List<string>> value in folderStructure)
		{
			folders.Add (value.Key);
		}
		return folders;
	}

	public void addFile (string destinationFolder,string fileName)
	{
		if (!folderStructure.ContainsKey (destinationFolder))
		{
			destinationFolder = "System";
		}
		folderStructure[destinationFolder].Add(fileName);
	}
}
