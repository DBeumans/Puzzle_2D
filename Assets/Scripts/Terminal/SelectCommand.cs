using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : MonoBehaviour 
{
    private CheckTerminalInput checkInput;
    private int index;

    private void Awake()
    {
        index = 0;
        checkInput = GameObject.FindGameObjectWithTag(Tags.terminal).GetComponent<CheckTerminalInput>();
    }

    public string getCommand(int value)
    {
        var commands = checkInput.getPreviousCommands;

        index += value;
        if (index < 0)
            index = commands.Count - 1;

        if (index > commands.Count - 1)
            index = commands.Count - 1; 

        if (commands.Count > 0)
            return commands[index];
        
        return "";
    }
}
