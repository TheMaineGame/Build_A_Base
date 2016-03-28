using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BuildingSpawner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler 
{
	[SerializeField] GameObject building;
	private bool pointerDown = false;

	void Start () 
	{

	}
	
	void Update () 
	{
	
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log ("PointerDown");
		pointerDown = true;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log ("PointerUP");
		pointerDown = false;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		if (pointerDown) {
			Debug.Log ("PointerExit");
			eventData.selectedObject = GameObject.Instantiate (building);
			pointerDown = false;
		}
	}
}
