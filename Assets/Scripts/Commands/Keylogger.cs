using System.Collections;

using UnityEngine;

public class Keylogger : MonoBehaviour
{
	private bool loggerExists;
	public bool LoggerExists{get{return loggerExists;}}

	private bool onServer;
	public bool OnServer{get{return onServer;}}

	private KeyloggerUI ui;

	private void Start()
	{
		loggerExists = false;
		onServer = false;

		ui = GetComponent<KeyloggerUI> ();
	}

	public string createLogger()
	{
		if (loggerExists)
		{
			return "Another instance of the keylogger is already running, please use 'stopKeylogger' to stop the current instance.";
		}
		loggerExists = true;
		return "Successfully instantiated the keylogger!\nUse 'uploadLogger [ipadress]' to move it to the connected server.";
	}

	public string upload(string ipAdress)
	{
		if (string.IsNullOrEmpty (ipAdress))
		{
			return "You must enter a valid ipAdress";
		}

		if (!loggerExists)
		{
			return "No active instance of the logger is running, please use 'instantiateKeylogger' to create an instance of the logger.";
		}
		if (onServer)
		{
			return "Your keylogger is already running on a server, please use 'stopKeylogger' to stop the current instance.";
		}

		if (ConnectToComputer.getUser == null)
		{
			return "You are not connected to any server, please use 'connect [ipadress]' to connect to a server.";
		}

		if (ConnectToComputer.getUser.getIp != ipAdress)
		{
			return "Could not connect to ipadress.";
		}

		onServer = true;
		return "Successfully uploaded keylogger to server.";
	}

	public string stoplogger()
	{
		if (loggerExists)
		{
			loggerExists = false;
			onServer = false;
			return "Stopped current instance of the keylogger.";
		}
		return "There is no active instance of the keylogger.";
	}

	public string startKeylogger()
	{
		if (!loggerExists)
		{
			return "No instance of the keylogger found.please use 'instantiateKeylogger' to create an instance of the logger.";
		}

		if(!onServer)
		{
			return "The keylogger is not on any server, please Use 'uploadLogger [ipadress]' to move it to the connected server.";
		}
		StartCoroutine ("logStart");
		return "Successfully started the keylogger.\nYou will be notified on the webpage.";
	}

	private IEnumerator logStart()
	{
		yield return new WaitForSeconds (1);
		string log = "";
		log += "www.trello.com\n";
		log += "propture\n";
		log += "CompanyName31\n";
		log += "\nwww.national-bank.nl\n";
		log += ConnectToComputer.getUser.Username+"\n";
		log += ConnectToComputer.getUser.Password+"\n";
		ui.updateResults (log);
	}
}