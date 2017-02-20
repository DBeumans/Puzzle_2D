using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour {


    [SerializeField]GameObject myComputer;
    [SerializeField]GameObject lvl;

    InputBehaviour input;
    PlayerData myPlayerData;

    private void Start()
    {
        input = FindObjectOfType<InputBehaviour>();
        myPlayerData = FindObjectOfType<PlayerData>();
    }
    private void Update()
    {
        if (input.GetEKey)
        {
            SwitchCharacter();
        }
    }
    

    void SwitchCharacter()
    {
        if (myPlayerData.GetCurrentPlayer == "Computer")
        {
            print("sda");
            // Switch To Player
            lvl.SetActive(true);
            myComputer.SetActive(false);
            myPlayerData.GetCurrentPlayer = "Player";
        }
        else
        {
            print("dge");
            // Switch To Computer
            lvl.SetActive(false);
            myComputer.SetActive(true);
            myPlayerData.GetCurrentPlayer = "Computer";
        }
    }

}
