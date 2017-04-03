using UnityEngine;
using System.Runtime.Serialization;

public class Surrogates
{
	public static void AddSurrogates(ref SurrogateSelector surrogateSelector)  
	{
		Vector3Surrogate Vector3_SS = new Vector3Surrogate();
		surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), Vector3_SS); 

		Texture2DSurrogate Texture2D_SS = new Texture2DSurrogate();
		surrogateSelector.AddSurrogate(typeof(Texture2D), new StreamingContext(StreamingContextStates.All), Texture2D_SS);

		ColourSurrogate Color_SS = new ColourSurrogate();
		surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), Color_SS);

		GameObjectSurrogate GameObject_SS = new GameObjectSurrogate();
		surrogateSelector.AddSurrogate(typeof(GameObject), new StreamingContext(StreamingContextStates.All), GameObject_SS);

		TransformSurrogate Transform_SS = new TransformSurrogate();
		surrogateSelector.AddSurrogate(typeof(Transform), new StreamingContext(StreamingContextStates.All), Transform_SS);

		QuaternionSurrogate Quaternion_SS = new QuaternionSurrogate();
		surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), Quaternion_SS);
	}
}