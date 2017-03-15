using System;
using System.Collections.Generic;

using UnityEngine;

public class CommandHandler : MonoBehaviour 
{
	public Dictionary<CommandID, CommandBehaviour> commands;

	private void Start()
	{
		commands = new Dictionary<CommandID, CommandBehaviour> ();
	}

	public void RunCommand(CommandID command, string[] arguments)
	{
		if (!commands.ContainsKey (command))
		{
			return;
		}

		commands [command].Run (arguments);
	}

	public void AddCommand(CommandID id, CommandBehaviour command)
	{
		commands.Add (id, command);
	}
}
