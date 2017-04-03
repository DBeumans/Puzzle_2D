public class ShutdownCommand : CommandBehaviour 
{
	public override void Run(string[] arguments)
	{
		UnityEngine.Application.Quit ();
	}
}
