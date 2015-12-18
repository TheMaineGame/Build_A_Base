using UnityEngine;
using System.Collections;

public class UI_Buttons : MonoBehaviour 
{
	[SerializeField]GameObject m_livingQuarters;

	public void CubeCall () 
	{
		m_livingQuarters.SetActive (true);
	}
}
