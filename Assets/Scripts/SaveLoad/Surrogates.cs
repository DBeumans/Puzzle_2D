using UnityEngine;
using System.Runtime.Serialization;

public class Surrogates
{
	public static void AddSurrogates(ref SurrogateSelector ss)  
	{
		Vector3Surrogate Vector3_SS = new Vector3Surrogate();
		ss.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), Vector3_SS); 

		Texture2DSurrogate Texture2D_SS = new Texture2DSurrogate();
		ss.AddSurrogate(typeof(Texture2D), new StreamingContext(StreamingContextStates.All), Texture2D_SS);

		ColorSurrogate Color_SS = new ColorSurrogate();
		ss.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), Color_SS);

		GameObjectSurrogate GameObject_SS = new GameObjectSurrogate();
		ss.AddSurrogate(typeof(GameObject), new StreamingContext(StreamingContextStates.All), GameObject_SS);

		TransformSurrogate Transform_SS = new TransformSurrogate();
		ss.AddSurrogate(typeof(Transform), new StreamingContext(StreamingContextStates.All), Transform_SS);

		QuaternionSurrogate Quaternion_SS = new QuaternionSurrogate();
		ss.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), Quaternion_SS);
	}
}