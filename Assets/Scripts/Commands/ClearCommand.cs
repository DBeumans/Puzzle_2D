public class ClearCommand : CommandBehaviour 
{
	public override void Run (string[] arguments)
	{
		output.clear ();
	}
}
