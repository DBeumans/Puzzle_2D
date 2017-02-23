using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class LoadProperties : MonoBehaviour 
{
	public static List<SaveData> Load()
	{
		string path = Application.persistentDataPath + "/saveData.dat"; 
		BinaryFormatter binary = new BinaryFormatter();
		SurrogateSelector surrogater = new SurrogateSelector();
		Surrogates.AddSurrogates(ref surrogater);
		binary.SurrogateSelector = surrogater;

		FileStream file = File.Open(path, FileMode.Open);
		if (file == null)
		{
			throw new Exception ("Failed to open file :(");
		}
		List<SaveData> loadedGame = (List<SaveData>)binary.Deserialize(file);
		file.Close();
		return loadedGame;
	}
}