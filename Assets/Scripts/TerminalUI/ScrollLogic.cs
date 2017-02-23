using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLogic : MonoBehaviour 
{
	[SerializeField]private ScrollRect scrollingWindow;
	[SerializeField]private Text text;

	public void updateWindow()
	{
		scrollingWindow.verticalNormalizedPosition = 0f;
	}
}
