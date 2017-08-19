using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class KeyloggerUI : MonoBehaviour 
{
	[SerializeField]private InputField logResults;

	private void Start()
	{
        setStartMessage();
	}

    private void setStartMessage()
    {
        logResults.text = "There are no log results yet, please run an instance of the keylogger from the termnial.\n\n";
        logResults.text += "If an instance is already running, please have patience till the logger has collected information.\n";
    }

    public void updateResults(string log, float waitTime)
	{
        if (!string.IsNullOrEmpty(log))
            StartCoroutine(update(log, waitTime));
	}

    private IEnumerator update(string log, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        logResults.gameObject.SetActive(false);
        logResults.text = log;
        logResults.gameObject.SetActive(true);
    }
}
