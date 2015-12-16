using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    /// <summary>
    /// The object the camera "holds onto", centered on the ground.
    /// The camera moves along a given line cast outward from this pivot,
    /// and as the name implies this object rotates with the camera.
    /// The camera should be a child of the pivot.
    /// </summary>
    [SerializeField]
    GameObject m_cameraPivot;

    /// <summary>
    /// The actual camera object that is attached to the pivot.
    /// </summary>
    [SerializeField]
    Camera m_camera;

    /// <summary>
    /// Maximum zoom level of the camera.
    /// Higher level means "closer".
    /// </summary>
    [SerializeField]
    float m_maxZoom;

    /// <summary>
    /// Minimum zoom level of the camera.
    /// Lower level means "further".
    /// </summary>
    [SerializeField]
    float m_minZoom;

    /// <summary>
    /// The speed at which the camera zooms. Think of this as
    /// "sensitivity" for the mouse wheel.
    /// </summary>
    [SerializeField]
    float m_zoomSpeed;

    /// <summary>
    /// The speed at which the camera rotates. A higher value
    /// naturally means more "rigid" rotations.
    /// </summary>
    [SerializeField]
    float m_rotateSpeed;

    /// <summary>
    /// Movement speed of the camera.
    /// This is the "raw" movement speed; To make the camera move
    /// in the right direction, it is inverted when accessed through
    /// the property below. A negative value will make the camera
    /// move all weird. 
    /// </summary>
    [SerializeField]
    float m_moveSpeed;

    /// <summary>
    /// The "true" movement speed of the camera.
    /// This inverts the value of the m_moveSpeed value
    /// so it will move the camera properly as though
    /// the world were being dragged.
    /// </summary>
    public float MoveSpeed {
        get {
            return -m_moveSpeed;
        }
    }

    /// <summary>
    /// The multiplier that affects move speed based on zoom level.
    /// May need to be fine tuned for varying levels of zoom.
    /// </summary>
    [SerializeField]
    float m_moveZoomMultiplier = 0.002f;

    /// <summary>
    /// Current rotation of the camera.
    /// </summary>
    Quaternion m_fromRotation;
    /// <summary>
    /// Rotation the camera is turning towards.
    /// </summary>
    Quaternion m_toRotation;

    /// <summary>
    /// Current position of the camera.
    /// </summary>
    Vector3 m_fromPos;
    /// <summary>
    /// Position the camera is moving towards.
    /// </summary>
    Vector3 m_toPos;

    /// <summary>
    /// Angle the camera needs to turned. Used to calculate
    /// camera rotation. Based on mouse drag.
    /// </summary>
    float m_yDeg;
    /// <summary>
    /// X position of the mouse on the previous frame. Used to
    /// calculate movement and rotation; involved in calculating
    /// change in mouse movement. 
    /// </summary>
    float m_lastMouseX;
    /// <summary>
    /// Y position of the mouse on hte previous frame. Used to
    /// calculate movement and rotation; involved in calculating
    /// change in mouse movement. 
    /// </summary>
    float m_lastMouseY;

    /// <summary>
    /// Current zoom level of the camera.
    /// </summary>
    float m_currentZoom;

    void Start()
    {
        m_currentZoom = m_camera.orthographicSize;
    }

    void Update()
    {

        m_moveSpeed = m_moveZoomMultiplier * m_currentZoom;

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
        // NOTE: This if is for button DOWN -- detects only the first frame of the mouse being held
        // necessary to reset the last mouse position variables so glitches don't happen
        if (Input.GetMouseButtonDown(0))
        {
            m_lastMouseX = Input.mousePosition.x;
            m_lastMouseY = Input.mousePosition.y;
        }
        // THIS block is for EVERY frame the mouse is being held
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - m_lastMouseX;
            float deltaY = Input.mousePosition.y - m_lastMouseY;
            //fromPos = cameraObject.transform.localPosition;
            //toPos = transform.right * deltaX + transform.forward * deltaY + toPos;
            //cameraObject.transform.localPosition = Vector3.Lerp(fromPos, toPos, Time.deltaTime * moveSpeed);
            m_cameraPivot.transform.position = transform.forward * (deltaY * MoveSpeed) + transform.right * (deltaX * MoveSpeed) + m_camera.transform.position;
            m_lastMouseX = Input.mousePosition.x;
            m_lastMouseY = Input.mousePosition.y;
        }
    }

}
