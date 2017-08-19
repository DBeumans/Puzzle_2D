using UnityEngine;

public class BankLogic : MonoBehaviour 
{
    private string server;
    private ServersInSession serversInSession;
	private BankUI ui;
	private enum Bank
	{
		NationalBank,
		OtherBank
	}
	[SerializeField]private Bank currentBank;

	private void Start()
	{
		server = "";
		ui = GetComponent<BankUI> ();
		serversInSession = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ServersInSession> ();
	}

	public string signIn(string username, string password)
	{
        if (serversInSession.CurrentServer == null)
			return wrongLogin();

        if (serversInSession.CurrentServer.Bank != currentBank.ToString())
			return wrongLogin ();

        if (username != serversInSession.CurrentServer.Username || password != serversInSession.CurrentServer.Password)
			return wrongLogin ();
		server = username;
		connectToBank ();
		return "";
	}

	private string wrongLogin()
	{
		return "You have entered the wrong username/password combination, please try again.";
	}

	private void connectToBank()
	{
		ui.showPanel (0, false);
		ui.showPanel (1, true);
        ui.showContents (serversInSession.CurrentServer.Name, serversInSession.CurrentServer.Username, serversInSession.CurrentServer.Bank, serversInSession.CurrentServer.Money, serversInSession.CurrentServer.Code);
	}

	public string companySpendings()
	{
		string[] names = {
			"Goooooogel store:",
			"Things And Stuff:",
			"Store:",
			"Supplies4Me:",
			"Staplers:",
			"Paper Factory:",
			"Desk Plaza:",
			"Some Lamps, But Maily Chairs:",
			"ComputerBuilders:",
			"Vector:",
			"ShopShopShop:",
			"NationalBank ATM:",
			"Pear Store:",
			"Manly Tomatoes:",
			"Fruity Salads:",
			"UNITE:",
			"Dev-Software.com:"
		};

		float[] amount = {
			1000f,
			19.99f,
			3.99f,
			200f,
			450f,
			1999f,
			10000f,
			21.99f,
			1600f,
			1200f,
			6.99f
		};

		string temp = "";
		for (int i = 0; i < 6; i++)
			temp += (names [Random.Range (0, names.Length - 1)] + " $" + amount [Random.Range (0, amount.Length - 1)] + "\n");
		return temp;
	}
}
