using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class SaveValues : MonoBehaviour 
{
	private DateLogic dateLogic;
	private CollectObjects collectObjects;
	private string path;

	private void Start()
	{
		dateLogic = FindObjectOfType<DateLogic> ();
		collectObjects = new CollectObjects ();
		path = Application.persistentDataPath + "/dataValues.dat";
	}

	public string Save()
	{
		BinaryFormatter binary = new BinaryFormatter ();
		SurrogateSelector surrogater = new SurrogateSelector();
		FileStream fStream = File.Create(path);

		Surrogates.AddSurrogates(ref surrogater);
		binary.SurrogateSelector = surrogater;
	
		DataValues saver = new DataValues();
		saver.Hours = dateLogic.Hours;
		saver.Minutes = dateLogic.Minutes;
		saver.Day = dateLogic.Day;
		saver.Month = dateLogic.Month;
		saver.Year = dateLogic.Year;
		saver.GameObjects = collectObjects.collect ();

		binary.Serialize(fStream, saver);
		fStream.Close();
		return "Successfully saved your data!\n";
	}
}