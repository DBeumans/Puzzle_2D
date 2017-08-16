using UnityEngine;

public class ExitCommand : CommandBehaviour
{
    private TerminalUI computerUI;

	protected override void Start ()
	{
		base.Start ();
        computerUI = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<TerminalUI> ();
	}

	public override void Run (string[] arguments)
	{
        output.clear ();
		computerUI.enableTerminal (false);
	}
}
