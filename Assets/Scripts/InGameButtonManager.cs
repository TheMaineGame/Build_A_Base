using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class InGameButtonManager : MonoBehaviour {

    [SerializeField] AudioMixer Mixer;
    [SerializeField] GameObject EndCanvas;
    [SerializeField] GameObject WinCanvas;
    [SerializeField] GameObject UIButtons;

	public void DisplayFinalCanvas()
    {
        UIButtons.SetActive(false);
        EndCanvas.SetActive(true);
        WinCanvas.SetActive(false);
        Time.timeScale = 0.01f;
        Mixer.FindSnapshot("PausedFX").TransitionTo(.05f);
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
