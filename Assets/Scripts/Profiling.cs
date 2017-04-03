using System.Collections.Generic;
using UnityEngine;

public static class Profiling 
{
	private static float multiplier = 1000;
	private static Dictionary<string, float> processes = new Dictionary<string, float> ();

	public static void start(string processName)
	{
		if (processes.ContainsKey (processName))
		{
			Debug.Log ("Already logging " + processName);
			return;
		}
		processes.Add (processName, Time.realtimeSinceStartup * multiplier);

	}

	public static void end(string processName)
	{
		if (!processes.ContainsKey (processName))
		{
			Debug.Log (processName+" has not started");
			return;
		}
			
		var endTime = Time.realtimeSinceStartup * multiplier;
		var deltaTime = endTime - processes[processName];
		Debug.Log (processName + ": " + deltaTime + "ms");
		processes.Remove (processName);
	}
}
