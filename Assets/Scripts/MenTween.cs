using UnityEngine;
using System.Collections;

public class MenTween : MonoBehaviour {

	public void Pop(GameObject target)
    {
        iTween.ScaleFrom(target, iTween.Hash("x", 1, "y", 1));
    }
}
