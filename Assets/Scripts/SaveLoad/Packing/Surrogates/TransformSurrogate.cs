using System.Runtime.Serialization;
using UnityEngine;

sealed class TransformSurrogate : ISerializationSurrogate 
{	
	public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context)
	{
		Transform tr = (Transform) obj;
	}

	public System.Object SetObjectData(System.Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
	{
		Transform tr = (Transform) obj;	
		return obj;
	}
}