using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour {


    [SerializeField]GameObject myComputer;
    [SerializeField]GameObject lvl;

    InputBehaviour input;
    PlayerData myPlayerData;
    PlayerTriggerCollision myPlayerTriggerCollision;

    private void Start()
    {
        input = FindObjectOfType<InputBehaviour>();
        myPlayerData = FindObjectOfType<PlayerData>();
        myPlayerTriggerCollision = FindObjectOfType<PlayerTriggerCollision>();
        StartCoroutine(myUpdate(.5f));
    }

    IEnumerator myUpdate(float checkTime)
    {
        while(true)
        {
            if (input.GetEKey && myPlayerTriggerCollision.GetCanSwitch)
            {
                SwitchCharacter();
            }
            yield return new WaitForSeconds(checkTime/100);  
        }
    }


    void SwitchCharacter()
    {
        if (myPlayerData.GetCurrentPlayer == "Computer")
        {
            // Switch To Player
            lvl.SetActive(true);
            myComputer.SetActive(false);
            myPlayerData.GetCurrentPlayer = "Player";
        }
        else
        {
            // Switch To Computer
            lvl.SetActive(false);
            myComputer.SetActive(true);
            myPlayerData.GetCurrentPlayer = "Computer";
        }
    }

}
