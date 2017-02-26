using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LoadObjects : MonoBehaviour 
{
	private UnpackObject objectUnpacker;
	private void Start()
	{
		objectUnpacker = GetComponent<UnpackObject> ();
	}

	public void loadObjects(List<SaveData> loadedFile)
	{
		destroySavedObjects ();
		if (loadedFile == null)
		{
			throw new System.Exception ("Failed to load file!");
		}

		List<GameObject> gameObjects = new List<GameObject>();
		foreach (SaveData packedObject in loadedFile)
		{
			GameObject unpackedObject = objectUnpacker.unpack(packedObject);
			if(unpackedObject != null) 
			{
				gameObjects.Add(unpackedObject);
			}
		}

		foreach(GameObject go in gameObjects) 
		{
			string parentId = go.GetComponent<ObjectInformation>().getParentId();
			if(!string.IsNullOrEmpty(parentId)) 
			{
				foreach(GameObject go_parent in gameObjects) 
				{
					if(go_parent.GetComponent<ObjectInformation>().GetId == parentId) 
					{
						go.transform.parent = go_parent.transform;
					}
				}
			}
		}
	}

	private static void destroySavedObjects()
	{
		ObjectInformation[] objects = FindObjectsOfType<ObjectInformation>();
		foreach (ObjectInformation objectToRemove in objects)
		{
			Destroy (objectToRemove.gameObject);
		}
	}
}
