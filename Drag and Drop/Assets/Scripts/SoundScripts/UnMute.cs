using UnityEngine;
using System.Collections;

public class UnMute : MonoBehaviour {

	public GameObject mute;
	public GameObject volume;

	public void Sound () 
	{
		AudioListener.volume = 1;

		volume.SetActive (true);
		mute.SetActive (false);
	}
}
