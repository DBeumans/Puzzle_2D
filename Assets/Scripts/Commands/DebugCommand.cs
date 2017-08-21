﻿using UnityEngine;

public class DebugCommand : CommandBehaviour 
{
    private float originalLoadTime;

    private Money money;

    protected override void Start()
    {
        base.Start();
        money = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Money>();
        originalLoadTime = GameValues.LoadTime;
    }

    public override void Run(string[] arguments)
    {
        if (arguments.Length == 2)
        {
            if (arguments[1] == "NOTIME")
                noTime();

            if (arguments[1] == "SHOWMONEY")
                showMoney();
        }

        if (arguments.Length == 3)
        {
            if (arguments[1] == "GIVEMONEY")
                giveMoney(arguments[2]);
        }
    }

    private void noTime()
    {
        if (GameValues.LoadTime == 0)
        {
            GameValues.setLoadTime(originalLoadTime);
            return;
        }

        GameValues.setLoadTime(0);
    }

    private void giveMoney(object arg)
    {
        float amount;
        if (!float.TryParse(arg.ToString(), out amount))
            return;

        money.addMoney(amount);
    }

    private void showMoney(){output.addText("Current amount of money: " +GameValues.Money, false);}
}