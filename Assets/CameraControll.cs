using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public enum cameraMode {orthographic, perspective}

	public cameraMode cameraState;

    GameObject cameraObject;

    GameObject actuallCameraObject;

    Camera actuallCamera;

    [SerializeField]
    float maxZoom;

    [SerializeField]
    float minZoom;

    [SerializeField]
    float zoomSpeed;

    [Range (1,10)]
    public float rotateSpeed;

    float actuallRotate;

    [SerializeField]
    float moveSpeed;

    float moveZoomMultiplier;

    Quaternion fromRotation;
    Quaternion toRotation;

    Vector3 fromPos;
    Vector3 toPos;

    float yDeg;
    float lastMouseX;
    float lastMouseY;

    float currentZoom;

	bool cameraType;

    float fovOrsize;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    void Start()
	{
        cameraObject = this.gameObject;
        actuallCameraObject = this.gameObject.transform.GetChild(0).gameObject;
        actuallCamera = GetComponentInChildren<Camera>();
		CameraModeCheck ();
        //groundPlane = Plane (groundNormal, groundPoint);
    }

    void Update()
	{
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;
        Vector3 movement = new Vector3(0, 0, 0);

        //float fov = actuallCamera.fieldOfView;

        //Debug.Log (camstate);

        moveSpeed = moveZoomMultiplier * -currentZoom;

        actuallRotate = rotateSpeed * 100;

        if (!cameraType) {
			actuallCamera.orthographicSize = currentZoom;
		} else {
            //actuallCamera.fieldOfView = currentZoom * 5;
            actuallCameraObject.transform.localPosition = new Vector3(0, currentZoom, -currentZoom);
		}

        currentZoom -= (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);

        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(1))
        {
            yDeg += Input.GetAxis("Mouse X") * Time.deltaTime * actuallRotate;
            fromRotation = cameraObject.transform.rotation;
            toRotation = Quaternion.Euler(0, yDeg, 0);
            cameraObject.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * actuallRotate);
        }

        //if (Input.GetMouseButton(0))
        //{
        //    movement.x -= Input.GetAxis("Mouse X") * moveSpeed;
        //    movement.z -= Input.GetAxis("Mouse Y") * moveSpeed;
        //}

        //movement = cameraObject.transform.TransformDirection(movement);
        //movement.y = 0;
        ////movement.y -= 

        //Vector3 origin = cameraObject.transform.position;
        //Vector3 destination = origin;
        //destination.x += movement.x;
        //destination.z += movement.z;
        //destination.y += movement.y;

        //if(origin != destination)
        //{
        //    transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * moveSpeed * fovOrsize);
        //}

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

	void CameraModeCheck(){
		if (cameraState == cameraMode.orthographic) {
			actuallCamera.orthographic = true;
			currentZoom = actuallCamera.orthographicSize;
			moveZoomMultiplier = 0.002f;
            fovOrsize = actuallCamera.orthographicSize * 2;
            moveZoomMultiplier = screenWidth / screenHeight / 800;
            cameraType = false;
		} else {
			actuallCamera.orthographic = false;
			currentZoom = actuallCamera.fieldOfView;
			moveZoomMultiplier = 0.003f;
            fovOrsize = actuallCamera.fieldOfView;
            moveZoomMultiplier = (screenWidth / screenHeight / 1500);
            cameraType = true;
		}
	}
}
