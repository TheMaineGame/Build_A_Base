using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

    void Awake()
    {
        Time.timeScale = 1;
    }

	// Use this for initialization
	void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0,1*Time.deltaTime,0));
    }
}
