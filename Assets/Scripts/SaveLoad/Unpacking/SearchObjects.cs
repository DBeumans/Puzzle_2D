using UnityEngine;
using System.Collections.Generic;

public class SearchObjects : MonoBehaviour 
{
	private Dictionary<string,GameObject> prefabDictionary = new Dictionary<string, GameObject>();
	public Dictionary<string, GameObject> Prefabs{get{return prefabDictionary;}}

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
}
