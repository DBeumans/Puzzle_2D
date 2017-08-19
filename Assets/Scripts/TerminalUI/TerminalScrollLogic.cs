using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TerminalScrollLogic : MonoBehaviour 
{
	[SerializeField]private ScrollRect scrollingWindow;

    public void updateScroll()
    {
        print("update");
        Canvas.ForceUpdateCanvases();
        scrollingWindow.verticalScrollbar.value = 0f;
        Canvas.ForceUpdateCanvases();
    }
}
