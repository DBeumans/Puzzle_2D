using UnityEngine;

public class Server
{
	private string name;
	public string Name{get{return name;}}

	private string ip;
	public string IP{get{return ip;}}

	private bool firewall;
	public bool Firewall{get{return firewall;}}

	private string accountName;
	public string Username{get{return accountName;}}

	private string accountPass;
	public string Password{get{return accountPass;}}

    private float money;
    public float Money{get{return money;} set{money = value;}}

	private string bankName;
	public string Bank{get{return bankName;}}

	private string secretCode;
	public string Code{get{return secretCode;}}

	private string[] files;
	public string[] Files{get{return files;}}

	public Server()
	{
		files = new string[6];
		createFolders ();
		this.name = createRandomName ();
		this.ip = createRandomIP ();
		this.firewall = selectFirewall ();
		this.accountName = createRandomString (10);
		this.accountPass = createRandomString (10);
		this.money = makeMoney ();
		this.bankName = setBankName();
		this.secretCode = createRandomString (5);
	}

	public Server(string name)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = createRandomIP ();
		this.firewall = selectFirewall ();
		this.accountName = createRandomString (10);
		this.accountPass = createRandomString (10);
		this.money = makeMoney ();
		this.bankName = setBankName();
		this.secretCode = createRandomString (5);
	}

    public Server(float money)
    {
        files = new string[6];
        createFolders ();
        this.name = createRandomName ();
        this.ip = createRandomIP ();
        this.firewall = selectFirewall ();
        this.accountName = createRandomString (10);
        this.accountPass = createRandomString (10);
        this.money = money;
        this.bankName = setBankName();
        this.secretCode = createRandomString (5);
    }

	public Server(string name, string ip)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = ip;
		this.firewall = selectFirewall ();
		this.accountName = createRandomString (10);
		this.accountPass = createRandomString (10);
		this.money = makeMoney ();
		this.bankName = setBankName();
		this.secretCode = createRandomString (5);
	}

	public Server(string name, string ip, bool firewall)
	{
		files = new string[6];
		createFolders ();
		this.name = name;
		this.ip = ip;
		this.firewall = firewall;
		this.accountName = createRandomString (10);
		this.accountPass = createRandomString (10);
		this.money = makeMoney ();
		this.bankName = setBankName();
		this.secretCode = createRandomString (5);
	}

	public Server(string name, string ip, bool firewall, string accountName, string accountPass)
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
		this.secretCode = createRandomString (5);
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
		var index = Random.Range (0, names.Length - 1);
		return names[index];
	}

	private string createRandomIP()
	{
        string ip = Random.Range (0, 255) + "." + Random.Range (0, 255) + "." + Random.Range (0, 255) + "." + Random.Range (0, 255);
		return ip;
	}

	private bool selectFirewall()
	{
		var temp = Random.Range(0, 100) <= 20 ? false : true;
		return temp;
	}

	private string createRandomString(int length)
	{
		string temp = "";
		string[] letters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","v","w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","M","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7","8","9"};
		for (var i = 0; i < length; i++)
            temp += letters[Random.Range(0, letters.Length-1)];
		return temp;
	}

	private int makeMoney()
	{
		return Random.Range (100000, 300000);
	}

	private string setBankName()
	{
		return "NationalBank";
		//return Random.Range (0,100) <= 50 ? "NationalBank" : "OtherBank";
	}

	public void removeFirewall(){this.firewall = false;}
}
