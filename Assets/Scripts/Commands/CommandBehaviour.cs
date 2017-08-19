using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

public abstract class CommandBehaviour : MonoBehaviour 
{
	protected ShowOutput output;
	protected ServersInSession serversInSession;
    protected InputField terminalInputField;

    public Action OnDone;

	protected float loadTime;

	protected virtual void Start()
	{
		output = FindObjectOfType<ShowOutput> ();
		serversInSession = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ServersInSession> ();
        terminalInputField = this.GetComponentInChildren<InputField>();
        if (loadTime == 0)
			loadTime = 1;
	}

	public abstract void Run (string[] arguments);

	public virtual void Exit(){}

    protected virtual IEnumerator load(object[] arguments){yield return null;}

    protected virtual void done()
    {
        if (this.OnDone != null)
            this.OnDone();
    }
}
