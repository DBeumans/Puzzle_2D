using UnityEngine;

public class ExitCommand : CommandBehaviour
{
	private ComputerUI computerUI;

	protected override void Start ()
	{
		base.Start ();
		computerUI = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ComputerUI> ();
	}

	public override void Run (string[] arguments)
	{
		computerUI.enableTerminal (false);
		output.clear ();
	}
}
