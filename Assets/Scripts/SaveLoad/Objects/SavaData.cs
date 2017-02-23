using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
	public string objectName{get; set;}
	public string prefabName{get; set;}
	public string id{get; set;}
	public string idParent{get; set;}

	public bool active{get; set;}
	public Vector3 position{get; set;}
	public Vector3 localScale{get; set;}
	public Quaternion rotation{get; set;}

	public List<ComponentInfo> objectComponents = new List<ComponentInfo> ();
}