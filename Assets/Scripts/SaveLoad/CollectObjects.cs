using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour 
{
	private PackObject objectPacker;
	public CollectObjects()
	{
		objectPacker = new PackObject ();
	}

	public List<SaveData> collect()
	{
		List<SaveData> data = new List<SaveData> ();
		ObjectInformation[] objectsToSerialize = FindObjectsOfType(typeof(ObjectInformation)) as ObjectInformation[];

		foreach (ObjectInformation information in objectsToSerialize)
		{
			data.Add(objectPacker.pack(information));
		}
		return data;
	}
}
