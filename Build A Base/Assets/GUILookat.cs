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

    void Update () {
        guiScale = mainCamera.orthographicSize;
        transform.rotation = cameraRot.rotation;
        transform.localScale = new Vector3(guiScale / scaleing, guiScale / scaleing, guiScale / scaleing);
        transform.position = placePos.position;
    }
}
