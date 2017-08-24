using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour 
{
    [SerializeField]private MovieTexture video;
    private RawImage image;

    private void Start()
    {
        image = this.GetComponent<RawImage>();
        play(true);
    }

    private void play(bool loop)
    {
        image.texture = video as MovieTexture;
        video.loop = loop;
        video.Play();
    }
}
