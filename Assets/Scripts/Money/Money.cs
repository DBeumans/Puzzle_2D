using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Money : MonoBehaviour 
{
    private Server playerInfo;

    public void setPlayerInfo(Server playerInfo){this.playerInfo = playerInfo;}

    public void addMoney(float value)
    {
        if (playerInfo == null)
            return;
        
        playerInfo.Money += value;
        GameValues.setMoney(playerInfo.Money);
    }

    public bool substractMoney(float value)
    {
        if (playerInfo == null)
            return false;
        
        if (playerInfo.Money < value)
            return false;
       
        playerInfo.Money -= value;
        GameValues.setMoney(playerInfo.Money);
        return true;
    }
}
