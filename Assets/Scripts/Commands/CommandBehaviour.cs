using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

public abstract class CommandBehaviour : MonoBehaviour 
{
	protected ServersInSession serversInSession;
    protected TerminalScrollLogic scrollLogic;
    protected InputField terminalInputField;
    protected ShowOutput output;

    public Action OnDone;

	protected virtual void Start()
	{
		output = FindObjectOfType<ShowOutput> ();
        scrollLogic = FindObjectOfType<TerminalScrollLogic>();
        terminalInputField = this.GetComponentInChildren<InputField>();
		serversInSession = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ServersInSession> ();
	}

	public abstract void Run (string[] arguments);

	public virtual void Exit(){}

    protected virtual IEnumerator load(object[] arguments){yield return null;}

    protected virtual void done()
    {
        if (this.OnDone != null)
            this.OnDone();
        scrollLogic.updateScroll();
    }
}
