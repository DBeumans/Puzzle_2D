using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLogic : MonoBehaviour 
{
	[SerializeField]private ScrollRect scrollingWindow;
	[SerializeField]private Text text;
	private void Start()
	{
		//scrollingWindow.verticalNormalizedPosition = 1f;
	}
}
