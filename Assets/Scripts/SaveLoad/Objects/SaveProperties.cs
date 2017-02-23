using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveProperties : MonoBehaviour 
{

	public static string Save(List<SaveData> data)
	{

		BinaryFormatter binary = new BinaryFormatter();
		SurrogateSelector surrogater = new SurrogateSelector();

		Surrogates.AddSurrogates(ref surrogater);
		binary.SurrogateSelector = surrogater;

		string path = Application.persistentDataPath + "/Items.dat"; 
		FileStream fstream = File.Create (path);
		binary.Serialize(fstream, data);
		fstream.Close();
		return "Successfully saved your Objects!\nDone!\n";
	}

	private static void createFolder(string path) 
	{
		if (Directory.Exists(path))
		{
			return;
		}

		DirectoryInfo dir = Directory.CreateDirectory (path);
		if (dir == null)
		{
			throw new Exception ("Failed to create:" + path);
		}
	}
}