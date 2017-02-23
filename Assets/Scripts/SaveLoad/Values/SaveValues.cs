using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveValues : MonoBehaviour 
{

	public static string Save()
	{
		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fStream=File.Create(Application.persistentDataPath+"/dataValues.dat");
		DataValues saver = new DataValues();

		//saver.Level = levelScript.level;

		binary.Serialize(fStream, saver);
		fStream.Close();
		return "Successfully saved your datavalues!\n";
	}
}