using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveProperties : MonoBehaviour 
{
	private void Start()
	{
	}

	public string Save()
	{
		if (ConnectToComputer.getUser == null)
		{
			return "You are not connected to a server to upload your data to, your progress did not save!";
		}

		//create a new instance of the BinaryFormatter class, to serialize your stream in binary 
		BinaryFormatter binary = new BinaryFormatter ();
		//Make a new FileStream class, which allows you to read and write files
		FileStream fStream=File.Create(Application.persistentDataPath+"/savefile.dat");
		//Make a new instance of our SaveManager script
		SaveManager saver = new SaveManager();

		/*
		saver.Score = scoreScript.score;
		saver.Level = levelScript.level;
		*/

		//Serialize the stream
		binary.Serialize(fStream, saver);
		//And close it off
		fStream.Close();
		return "Saved your session!";
	}
}