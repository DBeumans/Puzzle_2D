using System.Runtime.Serialization;
using UnityEngine;

sealed class ColourSurrogate : ISerializationSurrogate 
{	
	public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context) 
	{
		Color colour = (Color) obj;
		info.AddValue("r", colour.r);
		info.AddValue("g", colour.g);
		info.AddValue("b", colour.b);
		info.AddValue("a", colour.a);
	}

	public System.Object SetObjectData(System.Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector) 
	{
		Color colour = (Color) obj;
		colour.r = (float)info.GetValue("r", typeof(float));
		colour.g = (float)info.GetValue("g", typeof(float));
		colour.b = (float)info.GetValue("b", typeof(float));
		colour.a = (float)info.GetValue("a", typeof(float));
		obj = colour;
		return obj;
	}
}