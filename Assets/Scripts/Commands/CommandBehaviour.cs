using UnityEngine;

using System.Collections;

public abstract class CommandBehaviour : MonoBehaviour 
{
	protected ShowOutput output;
	protected CurrentUsers users;
	protected float loadTime;

	protected virtual void Start()
	{
		output = FindObjectOfType<ShowOutput> ();
		users = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CurrentUsers> ();
        if (loadTime == 0)
			loadTime = 3;
	}

	public abstract void Run (string[] arguments);

	public virtual void Exit(){}

	protected virtual IEnumerator load(){yield return null;}
}
