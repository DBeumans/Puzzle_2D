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

	public SaveData pack(ObjectInformation objectToPack)
	{
		object[] allComponents = objectToPack.gameObject.GetComponents<Component>() as object[];
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
		objectData.objectName = objectToPack.GetName;
		objectData.prefabName = objectToPack.GetPrefabName;
		objectData.idParent = objectToPack.getParentId ();
		objectData.id = objectToPack.GetId;
		objectData.active = objectToPack.gameObject.activeSelf;
		objectData.position = objectToPack.transform.position;
		objectData.localScale = objectToPack.transform.localScale;
		objectData.rotation = objectToPack.transform.rotation;
		return objectData;
	}
}
