﻿using UnityEngine;
using System.Collections;

public class CallCube : MonoBehaviour 
{
	[SerializeField]GameObject m_livingQuarters;

	public void CubeCall () 
	{
        GameObject poop = Instantiate(m_livingQuarters);
        poop.transform.position = new Vector3(2.5f, 0f, -4.5f);
    }
}
