﻿using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public enum cameraMode {orthographic, perspective}
    public enum rotateMode {LeftClick = 0, RightClick = 1, MiddleClick = 2}
    public enum panMode {LeftClick = 0, RightClick = 1, MiddleClick = 2}

	public cameraMode cameraState;
    public rotateMode rotateButton;
    public panMode panButton;

    GameObject cameraObject;

    GameObject actuallCameraObject;

    Camera actuallCamera;

    int rotateInt;

    int panInt;

    GameObject focusPoint;

    [SerializeField]
    float maxZoom;

    [SerializeField]
    float minZoom;

    [SerializeField]
    float zoomSpeed;

    [Range (1,10)]
    public float rotateSpeed;

    float curZoom;

    float actuallRotate;

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
        focusPoint = GameObject.FindGameObjectWithTag("FocusPoint");
        transform.parent.position = new Vector3(0, 0, 0);
        panInt = (int)panButton;
        rotateInt = (int)rotateButton;
        cameraObject = this.gameObject;
        actuallCameraObject = this.gameObject.transform.GetChild(0).gameObject;
        actuallCamera = GetComponentInChildren<Camera>();
        CheckZoom();
		CameraModeCheck ();
        if (panInt == rotateInt)
        {
            throw new System.Exception("Buttons should not be the same");
        }
        //groundPlane = Plane (groundNormal, groundPoint);
    }

    void Update()
	{
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;
        Vector3 movement = new Vector3(0, 0, 0);

        curZoom = Mathf.Lerp(curZoom, currentZoom, Time.deltaTime * zoomSpeed);

        //float fov = actuallCamera.fieldOfView;

        //Debug.Log (camstate);
       

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(screenWidth/2 , screenHeight/2));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            //focusPoint.transform.position = hit.point;
            focusPoint.transform.localPosition = Vector3.Lerp(focusPoint.transform.position, hit.point, Time.deltaTime * 3);
            Debug.DrawLine(ray.origin, hit.point);
        }

        if(curZoom == currentZoom)
        {
            CheckZoom();
        }

        moveSpeed = moveZoomMultiplier * -currentZoom;

        actuallRotate = rotateSpeed * 100;

        if (!cameraType) {
            actuallCamera.orthographicSize = Mathf.Lerp(actuallCamera.orthographicSize, currentZoom, Time.deltaTime * zoomSpeed);
		} else {
            //actuallCamera.fieldOfView = currentZoom * 5;
            actuallCameraObject.transform.localPosition = new Vector3(0, curZoom, -curZoom);
		}

        currentZoom -= (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);

        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(rotateInt))
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

        if (Input.GetMouseButtonDown(panInt))
        {
            lastMouseX = Input.mousePosition.x;
            lastMouseY = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(panInt))
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
            moveZoomMultiplier = (screenWidth / screenHeight / 1200);
            cameraType = true;
		}
	}

    void CheckZoom()
    {
        curZoom = currentZoom;
    }
}
