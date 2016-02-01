using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public GameObject GameOverCanvas;

	public void Finish()
	{
		GameOverCanvas.SetActive (true);
	}
}

