using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TerminalScrollLogic : MonoBehaviour 
{
	[SerializeField]private ScrollRect scrollingWindow;

    public void updateScroll(){StartCoroutine (scroll());}

	private IEnumerator scroll()
	{
		Canvas.ForceUpdateCanvases();
		scrollingWindow.verticalNormalizedPosition = 0f;
		yield return new WaitForEndOfFrame();
	}
}
