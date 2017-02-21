using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadProperties : MonoBehaviour 
{
	private void Start()
	{

	}
	public void Load(string fileName)
	{
		//Check if the file that you are trying to load exists
		if (File.Exists (Application.persistentDataPath + "/savefile.dat"))
		{
			//Create a new instance of the BinaryFormatter to deserialize the stream
			BinaryFormatter binary = new BinaryFormatter ();
			//Open the filestream to the file we saved
			FileStream fStream = File.Open (Application.persistentDataPath + "/savefile.dat", FileMode.Open);
			//Deserialize the class with properties we saved
			SaveManager saver = (SaveManager)binary.Deserialize (fStream);
			//Close the stream 
			fStream.Close ();

			/*
			scoreScript.score = saver.Score;
			levelScript.level = saver.Level;
			*/
		} 
	}
}