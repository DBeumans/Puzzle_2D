using UnityEngine;

public class BankLogic : MonoBehaviour 
{
	private string user;
	private BankUI ui;

	private void Start()
	{
		user = "";
		ui = GetComponent<BankUI> ();
	}

	public string signIn(string username, string password)
	{
		if (ConnectToComputer.getUser == null)
		{
			return wrongLogin();
		}

		if (ConnectToComputer.getUser.Bank != "National-Bank")
		{
			return wrongLogin ();
		}

		if (username != ConnectToComputer.getUser.Username || password != ConnectToComputer.getUser.Password)
		{
			return wrongLogin ();
		}
		user = username;
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
		ui.showContents ();
	}
}
