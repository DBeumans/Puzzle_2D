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
		files = new string[4];
		createFolders ();
	}

	private void createFolders()
	{
		files[0] = "save.py";
		files[1] = Random.Range(0,100) <= 5 ? "nudes.jpeg" : "tjoepMachine.txt";
		files[2] = Random.Range(0,100) <= 50 ? "presentation_about_kittens.pptx" : "how_glass_is_made.docx";
		files[3] = Random.Range(0,100) <= 50 ? "how-to-sharpen-a-pencil.html" : "properties.dat";
	}
}
