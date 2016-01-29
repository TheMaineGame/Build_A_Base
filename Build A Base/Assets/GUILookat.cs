using UnityEngine;
using System.Collections;

public class GUILookat : MonoBehaviour {

    [SerializeField]
    Transform cameraRot;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    float scaleing;

    [SerializeField]
    Transform placePos;

    float guiScale;

	bool cameraMode;

	void Start(){
		if (mainCamera.orthographic) {
			cameraMode = false;
		} else {
			cameraMode = true;
		}
	}

    void Update () {
		if (!cameraMode) {
			guiScale = mainCamera.orthographicSize;
		} else {
			guiScale = mainCamera.fieldOfView/5;
		}

        transform.rotation = cameraRot.rotation;
        transform.localScale = new Vector3(guiScale / scaleing, guiScale / scaleing, guiScale / scaleing);
        transform.position = placePos.position;

    }
}
