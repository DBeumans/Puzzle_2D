using UnityEngine;

public abstract class CommandBehaviour : MonoBehaviour 
{
	protected ShowOutput output;
	protected CurrentUsers users;

	protected virtual void Start()
	{
		output = FindObjectOfType<ShowOutput> ();
		users = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CurrentUsers> ();
	}

	public abstract void Run (string[] arguments);

	public virtual void Exit(){}
}
