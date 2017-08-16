using System.Collections.Generic;
using UnityEngine;

public enum CommandID
{
	NullCommand,
	scan,
	help,
	checkForFirewall,
	connect,
	disconnect,
	ls,
	attackFirewall,
	instantiateKeylogger,
	startKeylogger,
	exit,
	clear,
	python,
	transfer,
	tjoep,
	shutdown,
	length
}

public class CheckTerminalInput : MonoBehaviour 
{
	private CommandHandler commands;
	private ShowOutput output;

    [SerializeField]private List<string> usedCommands = new List<string> ();
	public List<string> getPreviousCommands{get{return usedCommands;}}

	private void Start()
	{
		commands = GetComponent<CommandHandler> ();
		output = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ShowOutput> ();
		CreateCommands ();
	}

	private void CreateCommands()
	{
		commands.AddCommand (CommandID.scan, GetComponent<ScanCommand>());
		commands.AddCommand (CommandID.help, GetComponent<HelpCommand>());
		commands.AddCommand (CommandID.checkForFirewall, GetComponent<CheckFirewallCommand>());
		commands.AddCommand (CommandID.connect, GetComponent<ConnectCommand>());
		commands.AddCommand (CommandID.disconnect, GetComponent<DisconnectCommand>());
		commands.AddCommand (CommandID.ls, GetComponent<lsCommand>());
		commands.AddCommand (CommandID.attackFirewall, GetComponent<AttackFirewallCommand>());
		commands.AddCommand (CommandID.instantiateKeylogger, GetComponent<KeylogCommand>());
		commands.AddCommand (CommandID.startKeylogger, GetComponent<KeylogStartCommand>());
		commands.AddCommand (CommandID.exit, GetComponent<ExitCommand>());
		commands.AddCommand (CommandID.clear, GetComponent<ClearCommand>());
		commands.AddCommand (CommandID.python, GetComponent<PythonCommand>());
		commands.AddCommand (CommandID.transfer, GetComponent<TransferCommand>());
		commands.AddCommand (CommandID.tjoep, GetComponent<TjoepCommand>());
		commands.AddCommand (CommandID.shutdown, GetComponent<ShutdownCommand>());
	}

	public void CheckInput(string input)
	{
		usedCommands.Add (input);
		string[] arguments = input.Split (new string[]{" "}, System.StringSplitOptions.None);

		foreach (var command in commands.commands.Keys)
		{
			if (arguments [0] == command.ToString ())
			{
				commands.RunCommand (command, arguments);
				return;
			}
		}
		output.addText (arguments[0] + ": command not found",false);
	}
}
