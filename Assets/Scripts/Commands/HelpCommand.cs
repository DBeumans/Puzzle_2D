public class HelpCommand : CommandBehaviour
{
	public override void Run (string[] arguments)
	{
		string response = "";
		response += "type 'help' to view all commands.\n";
		response += "type 'scan' to to scan for nearby servers.\n";
		response += "type 'checkForFirewall [IP adress]' to check if the server has an active firewall.\n";
		response += "type 'connect [IP adress] to connect to a server without active firewall.\n";
		response += "type 'attackFirewall [IP adress]' to open attack.exe and attack a firewal.\n";
		response += "type 'ls' while connected to someone to show the servers contents.\n";
		response += "type 'python [filename.py]' to execute a python script.\n";
		response += "type 'instantiateKeylogger [IP adress]' to create an instance of the keylogger and upload it to the server.\n";
		response += "type 'startKeylogger' to start the keylogger.\n";
		response += "type 'disconnect' to disconnect from a server.\n";
		response += "type 'clear' to clear the terminal.\n";
		response += "type 'exit' to exit your terminal and return to the desktop.\n";
		output.addText (response, false);
	}
}
