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

	private string[] names = {
		"Niko",
		"Slayer, Bringer Of Death",
		"Sumsung",
		"Banana",
		"Tender",
		"Graatje",
		"Cookie",
		"Cookie",
		"Rainbow Sparkles",
		"Yeskia",
		"Peaches"
	};

	public User(string name, string ip, bool firewall)
	{
		this.name = name;
		this.ip = ip;
		this.firewall = firewall;
		files = new string[6];
		createFolders ();
	}

	public User()
	{
		files = new string[6];
		createFolders ();
		this.name = createRandomName ();
		this.ip = createRandomIP ();
		this.firewall = selectFirewall ();
	}

	public User(string name)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = createRandomIP ();
		this.firewall = selectFirewall ();
	}

	public User(string name, string ip)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = ip;
		this.firewall = selectFirewall ();
	}

	private void createFolders()
	{
		files[0] = "save.py";
		files[1] = Random.Range(0,100) <= 5 ? "nudes.jpeg" : "tjoepMachine.txt";
		files[2] = Random.Range(0,100) <= 50 ? "presentation_about_kittens.pptx" : "how_glass_is_made.docx";
		files[3] = Random.Range(0,100) <= 50 ? "how-to-sharpen-a-pencil.html" : "properties.dat";
		files[4] = Random.Range(0,100) <= 50 ? "Beam.exe" : "Photochange.exe";
		files[5] = "load.py";
	}

	private string createRandomName()
	{
		int index = Random.Range (0, names.Length - 1);
		return names[index];
	}

	private string createRandomIP()
	{
		int firstPair = Random.Range (0,99);
		int secondPair = Random.Range (0,999);
		int thirdPair = Random.Range (0,99);
		int fourthPair = Random.Range (0,999);

		string ip = Random.Range (10, 99) + "." + Random.Range (10, 999) + "." + Random.Range (10, 99) + "." + Random.Range (10, 999);
		return ip;
	}

	private bool selectFirewall()
	{
		bool temp = Random.Range(0,100) <= 50 ? true : false;
		return temp;
	}
}
