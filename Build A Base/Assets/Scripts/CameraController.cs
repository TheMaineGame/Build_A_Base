using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject m_cameraPivot;

    [SerializeField]
    Camera m_camera;

    [SerializeField]
    float m_maxZoom;

    [SerializeField]
    float m_minZoom;

    [SerializeField]
    float m_zoomSpeed;

    [SerializeField]
    float m_rotateSpeed;

    [SerializeField]
    float m_moveSpeed;

    [SerializeField]
    float m_moveZoomMultiplier = 0.002f;

    Quaternion m_fromRotation;
    Quaternion m_toRotation;

    Vector3 m_fromPos;
    Vector3 m_toPos;

    float m_yDeg;
    float m_lastMouseX;
    float m_lastMouseY;

    float m_currentZoom;

    void Start()
    {
        m_currentZoom = m_camera.orthographicSize;
    }

    void Update()
    {

        m_moveSpeed = m_moveZoomMultiplier * -m_currentZoom;

        m_camera.orthographicSize = m_currentZoom;

        m_currentZoom -= (Input.GetAxis("Mouse ScrollWheel") * m_zoomSpeed);

        m_currentZoom = Mathf.Clamp(m_currentZoom, m_minZoom, m_maxZoom);

        if (Input.GetMouseButton(1))
        {
            m_yDeg += Input.GetAxis("Mouse X") * Time.deltaTime * m_rotateSpeed;
            m_fromRotation = m_cameraPivot.transform.rotation;
            m_toRotation = Quaternion.Euler(0, m_yDeg, 0);
            m_cameraPivot.transform.rotation = Quaternion.Lerp(m_fromRotation, m_toRotation, Time.deltaTime * m_rotateSpeed);
        }
        if (Input.GetMouseButtonDown(0))
        {
            m_lastMouseX = Input.mousePosition.x;
            m_lastMouseY = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - m_lastMouseX;
            float deltaY = Input.mousePosition.y - m_lastMouseY;
            //fromPos = cameraObject.transform.localPosition;
            //toPos = transform.right * deltaX + transform.forward * deltaY + toPos;
            //cameraObject.transform.localPosition = Vector3.Lerp(fromPos, toPos, Time.deltaTime * moveSpeed);
            m_cameraPivot.transform.position = transform.forward * (deltaY * m_moveSpeed) + transform.right * (deltaX * m_moveSpeed) + cameraObject.transform.position;
            m_lastMouseX = Input.mousePosition.x;
            m_lastMouseY = Input.mousePosition.y;
        }
    }

}
