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
			StopCoroutine ("logStart");
			return "Keylogger has finished or was stopped manually.";
		}
		return "There is no active instance of the keylogger.";
	}

	public string startKeylogger()
	{
		if (!loggerExists)
		{
			return "No instance of the keylogger found, please use 'instantiateKeylogger' to create an instance of the logger.";
		}

		if(!onServer)
		{
			return "The keylogger is not on any server, please Use 'uploadLogger [ipadress]' to move it to the connected server.";
		}
		StartCoroutine ("logStart");
		return "Successfully started the keylogger.\nYour logs will be send to the the 'Keylog-Results' tab in your Xplorer.";
	}

	private IEnumerator logStart()
	{
		loggerExists = true;
		yield return new WaitForSeconds (1);
		string[] logItems = 
		{
			//"\nwww.prello.com{return}\n{tab}\npropture{return}\nCompanyName31{return}\n",
			"\n"+ConnectToComputer.getUser.Bank+"{return}\n{tab}\n" + ConnectToComputer.getUser.Username + "{return}\n" + ConnectToComputer.getUser.Password + "{return}\n",
			//"\nwww.headbook.com{return}\n{tab}\nJohn Doe{return}\nAmsterdam191{return}\n",
			//"\nwww.offline.com{return}\n{tab}\n" + ConnectToComputer.getUser.getName + "{return}\nDirtyProstate16{return}\n",
			"\nwww.Vyves.nl{return}\n{tab}\nJohn Doe{return}\nMonsterCock123{return}\n"
		};
		string log = "";
		for(int i = 0; i<3; i++)
		{
			log+=logItems[Random.Range(0,logItems.Length-1)]; 
		}
		ui.updateResults (log);
		stoplogger ();
	}
}