using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

public class UnpackComponent : MonoBehaviour 
{
	public void unpack(ref GameObject gameObject, SaveData sceneObject) 
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
