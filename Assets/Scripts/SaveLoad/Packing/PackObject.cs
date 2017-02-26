using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PackObject
{
	private PackComponent componentPacker;
	public PackObject()
	{
		componentPacker = new PackComponent ();
	}

	public SaveData pack(ObjectInformation objectToPackage)
	{
		object[] allComponents = objectToPackage.gameObject.GetComponents<Component>() as object[];
		List<string> allowedComponents = new List<string> () {"UnityEngine.Collider", "UnityEngine.MonoBehaviour", "UnityEngine.Collider2D", "UnityEngine.Component"};
		List<ComponentInfo> componentsToSave = new List<ComponentInfo> ();

		foreach (object component in allComponents)
		{
			for (int i = 0; i < allowedComponents.Count; i++)
			{
				if (allowedComponents[i].Contains (component.GetType ().BaseType.FullName))
				{
					componentsToSave.Add (componentPacker.pack(component));
				}
			}
		}

		SaveData objectData = new SaveData ();
		objectData.objectName = objectToPackage.GetName;
		objectData.prefabName = objectToPackage.GetPrefabName;
		objectData.idParent = objectToPackage.getParentId ();
		objectData.id = objectToPackage.GetId;
		objectData.active = objectToPackage.gameObject.activeSelf;
		objectData.position = objectToPackage.transform.position;
		objectData.localScale = objectToPackage.transform.localScale;
		objectData.rotation = objectToPackage.transform.rotation;
		return objectData;
	}
}
