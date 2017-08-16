using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectInformation : MonoBehaviour 
{
	private string name;
	public string GetName{get{return name;}}

	[SerializeField]private string prefabName;
	public string GetPrefabName{get{return prefabName;}}

	private string id;
	public string GetId{get{return id;}}

	private bool isActive;
	public bool GetActive{get{return isActive;}}

	private Vector3 position;
	public Vector3 GetPosition{get{return position;}}

	private Vector3 localScale;
	public Vector3 GetScale{get{return localScale;}}

	private Quaternion rotation;
	public Quaternion GetRotation{get{return rotation;}}

	private void Start()
	{
		this.name = this.gameObject.name;
		this.id = System.Guid.NewGuid ().ToString();
	}

	public string getParentId()
	{
		if (this.transform.parent == null)
		{
			return null;
		}

		ObjectInformation parentInfo; 
		if(!(parentInfo = GetComponent<ObjectInformation>()))
		{
			return null;
		}
		return parentInfo.GetId;
	}
}
