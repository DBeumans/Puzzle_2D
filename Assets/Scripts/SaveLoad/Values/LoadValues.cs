using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadValues : MonoBehaviour 
{
	public static string Load()
	{
		if (File.Exists (Application.persistentDataPath + "/dataValues.dat"))
		{

			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (Application.persistentDataPath + "/dataValues.dat", FileMode.Open);
			DataValues saver = (DataValues)binary.Deserialize (fStream);
			fStream.Close ();

			//levelScript.level = saver.Level;
			return "Successfully Loaded your datavalues!\n";
		}
		return "Could not find the datavalues, have you saved before?";
	}
}