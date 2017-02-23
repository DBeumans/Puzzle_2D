using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveValues : MonoBehaviour 
{
	private DateLogic dateLogic;
	private void Start()
	{
		dateLogic = FindObjectOfType<DateLogic> ();
	}

	public string Save()
	{
		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fStream=File.Create(Application.persistentDataPath+"/dataValues.dat");
		DataValues saver = new DataValues();

		saver.Hours = dateLogic.Hours;
		saver.Minutes = dateLogic.Minutes;
		saver.Day = dateLogic.Day;
		saver.Month = dateLogic.Month;
		saver.Year = dateLogic.Year;

		binary.Serialize(fStream, saver);
		fStream.Close();
		return "Successfully saved your datavalues!\n";
	}
}