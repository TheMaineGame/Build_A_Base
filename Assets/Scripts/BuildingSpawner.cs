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
		pointerDown = true;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		pointerDown = false;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		pointerDown = false;
	}
}
