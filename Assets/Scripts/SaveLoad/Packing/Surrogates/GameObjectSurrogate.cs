using System.Runtime.Serialization;
using UnityEngine;

sealed class GameObjectSurrogate : ISerializationSurrogate 
{
	public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context)
	{
		GameObject go = (GameObject) obj;
	}

	public System.Object SetObjectData(System.Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector) 
	{
		GameObject go = (GameObject) obj;
		return obj;
	}
}