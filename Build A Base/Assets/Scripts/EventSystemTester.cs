using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class EventSystemTester : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    public void OnPointerClick (PointerEventData eventData) {
        Debug.Log ("Clicked on " + gameObject.name, gameObject);
    }

    public void OnPointerEnter (PointerEventData eventData) {
        Debug.Log ("Pointer entered " + gameObject.name, gameObject);
    }

    public void OnPointerExit (PointerEventData eventData) {
        Debug.Log ("Pointer exited" + gameObject.name, gameObject);
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
