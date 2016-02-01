using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

	public Animation animWind;
	public Animation animWater;
	public Animation animLiving;
	public Animation animCommunications;
	public Animation animPower;
	public Animation animRE;

	Vector3 dist;
	float posX;
	float posY;

	void OnMouseDown()
	{
		animWind.Stop();
		animWater.Stop();
		animLiving.Stop();
		animCommunications.Stop();
		animPower.Stop();
		animRE.Stop();

		dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	}
	void OnMouseDrag()
	{
		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.position = worldPos;
	}
	void OnMouseExit()
	{
		animWind.Play();
		animWater.Play();
		animLiving.Play();
		animCommunications.Play();
		animPower.Play();
		animRE.Play();
	}
}

