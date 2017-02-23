using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;


public class PackageObjects : MonoBehaviour 
{
	public static string SaveGame()
	{
		List<SaveData> data = new List<SaveData> ();
		ObjectInformation[] objectsToSerialize = FindObjectsOfType(typeof(ObjectInformation)) as ObjectInformation[];

		foreach (ObjectInformation information in objectsToSerialize)
		{
			data.Add(packageGameObject (information));
		}
		return SaveProperties.Save (data);
	}

	private static SaveData packageGameObject(ObjectInformation objectToPackage)
	{
		object[] allComponents = objectToPackage.gameObject.GetComponents<Component>() as object[];
		List<string> allowedComponents = new List<string> () {"UnityEngine.Collider", "UnityEngine.MonoBehaviour"};
		List<ComponentInfo> componentsToSave = new List<ComponentInfo> ();

		foreach (object component in allComponents)
		{
			for (int i = 0; i < allowedComponents.Count; i++)
			{
				if (allowedComponents[i].Contains (component.GetType ().BaseType.FullName))
				{
					componentsToSave.Add (packageComponent(component));
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

	private static ComponentInfo packageComponent(object component)
	{
		ComponentInfo componentInfo = new ComponentInfo();
		componentInfo.fields = new Dictionary<string, object>();

		const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
		var componentType = component.GetType();
		FieldInfo[] fields = componentType.GetFields(flags);

		componentInfo.componentName = componentType.ToString();

		foreach(FieldInfo field in fields) 
		{
			if (field != null) 
			{
				if(TypeSystem.IsEnumerableType(field.FieldType) || TypeSystem.IsCollectionType(field.FieldType)) 
				{
					Type elementType = TypeSystem.GetElementType(field.FieldType);
					if(!elementType.IsSerializable) 
					{
						continue;
					}
				}
				componentInfo.fields.Add(field.Name, field.GetValue(component));
			}
		}
		return componentInfo;
	}
}
