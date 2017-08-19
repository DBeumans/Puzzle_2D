using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour {


    [SerializeField]GameObject myComputer;
    [SerializeField]GameObject lvl;

    [SerializeField]private GameObject playerUI;

    InputBehaviour input;
    PlayerData myPlayerData;
    PlayerTriggerCollision myPlayerTriggerCollision;

    DesktopUI myComputerUI;

    private void Start()
    {
        input = FindObjectOfType<InputBehaviour>();
        myPlayerData = FindObjectOfType<PlayerData>();
        myPlayerTriggerCollision = FindObjectOfType<PlayerTriggerCollision>();
        myComputerUI = FindObjectOfType<DesktopUI>();
        StartCoroutine(myUpdate(.5f));
    }

    IEnumerator myUpdate(float checkTime)
    {
        while(true)
        {
            if (input.GetEKey && myPlayerTriggerCollision.GetCanSwitch)
            {
                if(myPlayerData.GetCurrentPlayer != "Computer")
                    SwitchCharacter();
            }

            if (myComputerUI.IsLoggedOut)
                SwitchCharacter();

            yield return new WaitForSeconds(checkTime/100);  
        }
    }


    void SwitchCharacter()
    {
        if (myPlayerData.GetCurrentPlayer == "Computer")
        {
            // Switch To Player
            lvl.SetActive(true);
            playerUI.SetActive(true);
            myComputer.SetActive(false);
            myPlayerData.GetCurrentPlayer = "Player";
            myComputerUI.IsLoggedOut = false;
        }
        else
        {
            // Switch To Computer
            lvl.SetActive(false);
            playerUI.SetActive(false);
            myComputer.SetActive(true);
            myPlayerData.GetCurrentPlayer = "Computer";
        }
    }

}
