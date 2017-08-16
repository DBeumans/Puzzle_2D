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
	private KeyWords keywords;
	private CollectObjects collectObjects;
	private string path;

	private void Start()
	{
		//Create references to the scripts
		dateLogic = FindObjectOfType<DateLogic> ();
        keywords = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<KeyWords> ();

		//Create new instance of the CollectObjects script
		collectObjects = new CollectObjects ();
		path = Application.persistentDataPath + "/dataValues.dat";
	}

	public string Save()
	{
		//Create a new instance of the BinaryFormatter
		BinaryFormatter binary = new BinaryFormatter ();
		//Create a new instance of the SurrogateSelector
		SurrogateSelector surrogate = new SurrogateSelector();
		//Create a new file on the path
		FileStream fStream = File.Create(path);

		//Add out custom surrogates to the Surrogate
		Surrogates.AddSurrogates(ref surrogate);
		//Add the surrogates to the BinaryFormatter
		binary.SurrogateSelector = surrogate;

		//Create a new instance of the DataValues script
		DataValues saver = new DataValues();
		//Set all the values you want to save
		saver.Hours = dateLogic.Hours;
		saver.Minutes = dateLogic.Minutes;
		saver.Day = dateLogic.Day;
		saver.Month = dateLogic.Month;
		saver.Year = dateLogic.Year;
		saver.GameObjects = collectObjects.collect ();
		saver.Keywords = keywords.Keywords;

		//Serialize the saverinstance to the fstream
		binary.Serialize(fStream, saver);
		//Close the stream
		fStream.Close();
		return "Successfully saved your data!";
	}
}
