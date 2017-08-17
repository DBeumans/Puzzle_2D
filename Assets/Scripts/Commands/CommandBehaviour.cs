using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public abstract class CommandBehaviour : MonoBehaviour 
{
	protected ShowOutput output;
	protected CurrentUsers users;
    protected InputField terminalInputField;

	protected float loadTime;

	protected virtual void Start()
	{
		output = FindObjectOfType<ShowOutput> ();
		users = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CurrentUsers> ();
        terminalInputField = this.GetComponentInChildren<InputField>();
        if (loadTime == 0)
			loadTime = 3;
	}

	public abstract void Run (string[] arguments);

	public virtual void Exit(){}

    protected virtual IEnumerator load(object[] arguments){yield return null;}
}
