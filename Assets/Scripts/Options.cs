using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {
    [SerializeField]
    Toggle mute;

    [SerializeField]
    Slider volumeLevel;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Update ()
    {
        Debug.Log(AudioListener.volume);
        if (mute.isOn == false)
        {
            AudioListener.volume = 0f;
        }
        else if (mute.isOn == true)
        {
            AudioListener.volume = volumeLevel.value;
        }
    }
}
