using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadValues : MonoBehaviour 
{
	private DateLogic dateLogic;

	private void Start()
	{
		dateLogic = FindObjectOfType<DateLogic> ();
	}
	public string Load()
	{
		if (File.Exists (Application.persistentDataPath + "/dataValues.dat"))
		{

			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (Application.persistentDataPath + "/dataValues.dat", FileMode.Open);
			DataValues saver = (DataValues)binary.Deserialize (fStream);
			fStream.Close ();

			dateLogic.Hours = saver.Hours;
			dateLogic.Minutes = saver.Minutes;
			dateLogic.Day = saver.Day;
			dateLogic.Month = saver.Month;
			dateLogic.Year = saver.Year;
			return "Successfully Loaded your datavalues!\n";
		}
		return "Could not find the datavalues, have you saved before?";
	}
}