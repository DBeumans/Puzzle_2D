using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

public class UnpackageObjects : MonoBehaviour 
{
	public static Dictionary<string,GameObject> prefabDictionary = new Dictionary<string, GameObject>();

	private void Awake()
	{
		GameObject[] prefabs = Resources.LoadAll<GameObject>("");
		foreach (GameObject loadedPrefab in prefabs)
		{
			if (loadedPrefab.GetComponent<ObjectInformation> ())
			{
				prefabDictionary.Add (loadedPrefab.name, loadedPrefab);
			}
		}
	}

	public static string LoadGame()
	{
		destroySavedObjects ();

		List<SaveData> loadedFile = LoadProperties.Load ();
		if (loadedFile == null)
		{
			throw new Exception ("Failed to load file :(");
		}
			
		List<GameObject> goList = new List<GameObject>();
		foreach (SaveData loadedObject in loadedFile)
		{
			GameObject unpackagedGO = UnpackGameObject(loadedObject);
			if(unpackagedGO != null) 
			{
				goList.Add(unpackagedGO);
			}
		}

		foreach(GameObject go in goList) 
		{
			string parentId = go.GetComponent<ObjectInformation>().getParentId();
			if(!string.IsNullOrEmpty(parentId)) 
			{
				foreach(GameObject go_parent in goList) 
				{
					if(go_parent.GetComponent<ObjectInformation>().GetId == parentId) 
					{
						go.transform.parent = go_parent.transform;
					}
				}
			}
		}
		return "Successfully loaded your objects!\nDone!\n";
	}

	private static void destroySavedObjects()
	{
		ObjectInformation[] objects = FindObjectsOfType<ObjectInformation>();
		foreach (ObjectInformation objectToRemove in objects)
		{
			Destroy (objectToRemove.gameObject);
		}
	}
		
	public static GameObject UnpackGameObject(SaveData data) 
	{
		if(!prefabDictionary.ContainsKey(data.prefabName)) 
		{
			throw new Exception ("Cannot find: " + data.prefabName+ ", did the path change after the last save?");
			return null;
		}

		GameObject gameObject = Instantiate(prefabDictionary[data.prefabName], data.position, data.rotation) as GameObject;

		gameObject.name = data.objectName;
		gameObject.transform.localScale = data.localScale;
		gameObject.SetActive (data.active);

		if(!gameObject.GetComponent<ObjectInformation>()) 
		{
			ObjectInformation oi = gameObject.AddComponent<ObjectInformation>();
		}
			
		UnpackComponents(ref gameObject, data);

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

	public static void UnpackComponents(ref GameObject gameObject, SaveData sceneObject) 
	{
		foreach(ComponentInfo information in sceneObject.objectComponents) 
		{
			if(!gameObject.GetComponent(information.componentName)) 
			{
				Type componentType = Type.GetType(information.componentName);
				gameObject.AddComponent(componentType);
			}

			object obj = gameObject.GetComponent(information.componentName) as object;

			var objectType = obj.GetType();
			foreach(KeyValuePair<string,object> p in information.fields) 
			{
				var field = objectType.GetField(p.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetField);
				if (field != null) 
				{
					object value = p.Value;
					field.SetValue(obj, value);
				}
			}
		}
	}
}
