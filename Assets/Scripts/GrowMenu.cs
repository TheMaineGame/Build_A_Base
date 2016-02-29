using UnityEngine;
using System.Collections;

public class GrowMenu : MonoBehaviour {
	
	void Start ()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("time", 2, "x", 1.25, "y", 1.25, "easetype", "linear"));
    }
}
