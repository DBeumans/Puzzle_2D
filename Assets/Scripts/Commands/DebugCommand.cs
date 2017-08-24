using UnityEngine;

public class DebugCommand : CommandBehaviour 
{
    private float originalLoadTime;

    private Money money;
    private ServersInSession serversInSession;

    protected override void Start()
    {
        base.Start();
        money = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Money>();
        serversInSession = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ServersInSession>();
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

            if (arguments[1] == "NOFIREWALL")
                removeFirewall();

            if (arguments[1] == "SHOWSERVERS")
                showServers();
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

    private void removeFirewall()
    {
        var servers = serversInSession.Servers;
        for (var i = 0; i < servers.Count; i++)
            servers[i].removeFirewall();
    }

    private void showServers()
    {
        var servers = serversInSession.Servers;
        for (var i = 0; i < servers.Count; i++)
        {
            output.addText("\n", false);
            output.addText("Name: " + servers[i].Name, false);
            output.addText("IP: " + servers[i].IP, false);
            output.addText("Bank: " + servers[i].Bank, false);
            output.addText("Username: " + servers[i].Username, false);
            output.addText("Password: " + servers[i].Password, false);
            output.addText("Transfer-code" + servers[i].Code, false);
            output.addText("Money: $" + servers[i].Money, false);
            output.addText("Firewall: " + servers[i].Firewall, false);
        }
    }
}
