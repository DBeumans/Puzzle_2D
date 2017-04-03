using System.Runtime.Serialization;
using UnityEngine;

sealed class Texture2DSurrogate : ISerializationSurrogate
{
	public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context)
	{
		Texture2D t = (Texture2D) obj;
	}

	public System.Object SetObjectData(System.Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
	{
		Texture2D t = (Texture2D) obj;
		return obj;
	}
}