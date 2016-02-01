using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	[SerializeField] float cameraSpeed;
	[SerializeField] float cameraFlyHeight;
	bool ZoomedIn = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0){
			gameObject.transform.Translate(Input.GetAxisRaw("Horizontal") * cameraSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical")*cameraSpeed*Time.deltaTime, 0);}

		if (Input.GetButtonDown ("Fire1") == true) {
			if (ZoomedIn == false) {
				Camera.main.fieldOfView = 10;
				ZoomedIn = true;
			} else{
				Camera.main.fieldOfView = 30;
				ZoomedIn = false;}
		}
	}


}
