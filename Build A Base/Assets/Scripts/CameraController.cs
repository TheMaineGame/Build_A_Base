using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject cameraObject;

    [SerializeField]
    Camera actuallCamera;

    [SerializeField]
    float maxZoom;

    [SerializeField]
    float minZoom;

    [SerializeField]
    float zoomSpeed;

    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float moveZoomMultiplier = 0.002f;

    Quaternion fromRotation;
    Quaternion toRotation;

    Vector3 fromPos;
    Vector3 toPos;

    float yDeg;
    float lastMouseX;
    float lastMouseY;

    float currentZoom;

    void Start()
    {
        currentZoom = actuallCamera.orthographicSize;
    }

    void Update()
    {

        moveSpeed = moveZoomMultiplier * -currentZoom;

        actuallCamera.orthographicSize = currentZoom;

        currentZoom -= (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);

        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(1))
        {
            yDeg += Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            fromRotation = cameraObject.transform.rotation;
            toRotation = Quaternion.Euler(0, yDeg, 0);
            cameraObject.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetMouseButtonDown(0))
        {
            lastMouseX = Input.mousePosition.x;
            lastMouseY = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - lastMouseX;
            float deltaY = Input.mousePosition.y - lastMouseY;
            //fromPos = cameraObject.transform.localPosition;
            //toPos = transform.right * deltaX + transform.forward * deltaY + toPos;
            //cameraObject.transform.localPosition = Vector3.Lerp(fromPos, toPos, Time.deltaTime * moveSpeed);
            cameraObject.transform.position = transform.forward * (deltaY * moveSpeed) + transform.right * (deltaX * moveSpeed) + cameraObject.transform.position;
            lastMouseX = Input.mousePosition.x;
            lastMouseY = Input.mousePosition.y;
        }
    }

}
