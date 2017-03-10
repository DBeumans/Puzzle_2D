using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLogic : MonoBehaviour 
{
	[SerializeField]private ScrollRect scrollingWindow;
	[SerializeField]private Text text;

	public void updateScroll()
	{
		StartCoroutine (scroll());
	}

	private IEnumerator scroll()
	{
		Canvas.ForceUpdateCanvases();
		scrollingWindow.verticalNormalizedPosition = 0f;
		yield return new WaitForEndOfFrame();
	}
}
