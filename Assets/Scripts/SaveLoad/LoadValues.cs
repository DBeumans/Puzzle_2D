using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class LoadValues : MonoBehaviour 
{
	private DateLogic dateLogic;
	private LoadObjects objects;
	private string path;

	private void Start()
	{
		dateLogic = FindObjectOfType<DateLogic> ();
		objects = GetComponent<LoadObjects> ();
		path = Application.persistentDataPath + "/dataValues.dat";
	}

	public string load()
	{
		if (File.Exists (path))
		{
			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (path, FileMode.Open);

			SurrogateSelector surrogater = new SurrogateSelector();
			Surrogates.AddSurrogates(ref surrogater);
			binary.SurrogateSelector = surrogater;

			DataValues saver = (DataValues)binary.Deserialize (fStream);
			fStream.Close ();

			dateLogic.Hours = saver.Hours;
			dateLogic.Minutes = saver.Minutes;
			dateLogic.Day = saver.Day;
			dateLogic.Month = saver.Month;
			dateLogic.Year = saver.Year;
			objects.loadObjects (saver.GameObjects);
			return "Successfully Loaded your data!\n";
		}
		return "Could not find the data, have you saved before?";
	}
}