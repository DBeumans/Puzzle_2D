using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Cheat : MonoBehaviour {

    private void Start()
    {
        foreach (Process pro in Process.GetProcesses())
        {
            try
            {
                if (pro.ProcessName.ToLower().Contains("cheat"))
                {
                    print("Cheat");
                }
            }
            catch {}
        }
    }
}
