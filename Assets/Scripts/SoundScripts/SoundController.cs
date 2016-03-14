using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundController : MonoBehaviour {
    [SerializeField] AudioSource SoundToMute;
    [SerializeField] Sprite MusicOn;
    [SerializeField] Sprite MusicOff;
    

	public void Sound () 
	{
		if (SoundToMute.volume == 0)
        {
            SoundToMute.volume = 1;
            gameObject.GetComponent<Image>().sprite = MusicOn;
        }
        else
        {
            SoundToMute.volume = 0;
            gameObject.GetComponent<Image>().sprite = MusicOff;
        }
	}
}
