using UnityEngine;
using System.Collections;

public class Mute : MonoBehaviour {
	public GameObject mute;
	public GameObject volume;

	public void Sound () 
	{
		AudioListener.volume = 0;

		mute.SetActive (true);
		volume.SetActive (false);
	}
}
