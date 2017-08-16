using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

public class UnpackObject : MonoBehaviour 
{
	private SearchObjects objects;
	private UnpackComponent componentUnpacker;

	private void Start()
	{
		objects = GetComponent<SearchObjects>();
		componentUnpacker = new UnpackComponent ();
	}

	public GameObject unpack(SaveData data) 
	{
		if(!objects.Prefabs.ContainsKey(data.prefabName)) 
		{
			throw new Exception ("Cannot find: " + data.prefabName+ ", did the path change after the last save?");
			return null;
		}

		GameObject gameObject = Instantiate(objects.Prefabs[data.prefabName], data.position, data.rotation) as GameObject;

		gameObject.name = data.objectName;
		gameObject.transform.localScale = data.localScale;
		gameObject.SetActive (data.active);

		if(!gameObject.GetComponent<ObjectInformation>()) 
		{
			ObjectInformation oi = gameObject.AddComponent<ObjectInformation>();
		}
			
		componentUnpacker.unpack(ref gameObject, data);

		ObjectInformation[] childrenIds = gameObject.GetComponentsInChildren<ObjectInformation>();
		foreach(ObjectInformation childrenIDScript in childrenIds) 
		{
			if(childrenIDScript.transform != gameObject.transform) 
			{
				if(string.IsNullOrEmpty(childrenIDScript.GetId)) 
				{
					Destroy (childrenIDScript.gameObject);
				}
			}
		}
		return gameObject;
	}
}
