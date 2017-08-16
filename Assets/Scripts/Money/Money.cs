using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Money : MonoBehaviour 
{
    private float amount;

    private void Start()
    {
        amount = 293.65f;
    }

    public void addMoney(float value)
    {
        amount += value;
    }

    public bool substractMoney(float value)
    {
        if (amount < value)
            return false;
       
        amount -= value;
        return true;
    }
}
