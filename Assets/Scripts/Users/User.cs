using UnityEngine;

public class User
{
	private string name;
	public string getName{get{return name;}}

	private string ip;
	public string getIp{get{return ip;}}

	private bool firewall;
	public bool getFirewall{get{return firewall;}}

	private string accountName;
	public string Username{get{return accountName;}}

	private string accountPass;
	public string Password{get{return accountPass;}}

	private int money;
	public int Money{get{return money;}}

	private string bankName;
	public string Bank{get{return bankName;}}

	private string[] files;
	public string[] getFiles{get{return files;}}

	public User()
	{
		files = new string[6];
		createFolders ();
		this.name = createRandomName ();
		this.ip = createRandomIP ();
		this.firewall = selectFirewall ();
		this.accountName = createRandomString ();
		this.accountPass = createRandomString ();
		this.money = makeMoney ();
		this.bankName = setBankName();
	}

	public User(string name)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = createRandomIP ();
		this.firewall = selectFirewall ();
		this.accountName = createRandomString ();
		this.accountPass = createRandomString ();
		this.money = makeMoney ();
		this.bankName = setBankName();
	}

	public User(string name, string ip)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = ip;
		this.firewall = selectFirewall ();
		this.accountName = createRandomString ();
		this.accountPass = createRandomString ();
		this.money = makeMoney ();
		this.bankName = setBankName();
	}

	public User(string name, string ip, bool firewall)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = ip;
		this.firewall = firewall;
		this.accountName = createRandomString ();
		this.accountPass = createRandomString ();
		this.money = makeMoney ();
		this.bankName = setBankName();
	}

	public User(string name, string ip, bool firewall, string accountName, string accountPass)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = ip;
		this.firewall = firewall;
		this.accountName = accountName;
		this.accountPass = accountPass;
		this.money = makeMoney ();
		this.bankName = setBankName();
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
		string[] names = {
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
		int index = Random.Range (0, names.Length - 1);
		return names[index];
	}

	private string createRandomIP()
	{
		int firstPair = Random.Range (0,99);
		int secondPair = Random.Range (0,999);
		int thirdPair = Random.Range (0,99);
		int fourthPair = Random.Range (0,999);

		string ip = Random.Range (10, 99) + "." + Random.Range (100, 999) + "." + Random.Range (10, 99) + "." + Random.Range (100, 999);
		return ip;
	}

	private bool selectFirewall()
	{
		bool temp = Random.Range(0,100) <= 40 ? false : true;
		return temp;
	}

	private string createRandomString()
	{
		string temp = "";
		string[] alphabet = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","v","w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","M","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7","8","9"};
		for (int i = 0; i < 10; i++)
		{
			temp += alphabet[Random.Range(0,alphabet.Length-1)];
		}
		return temp;
	}

	private int makeMoney()
	{
		return Random.Range (100000, 300000);
	}

	private string setBankName()
	{
		return Random.Range (0,100) <= 50 ? "National-Bank" : "Other bank";
	}
}
