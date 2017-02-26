using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

public class PackComponent
{
	public ComponentInfo pack(object component)
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
