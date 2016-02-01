using UnityEngine;
using System.Collections;

public class TestAnimationActivator : MonoBehaviour {

	[SerializeField] Animator anim;

	void Update(){
		if (Input.GetKeyDown (KeyCode.LeftControl))
		anim.SetTrigger ("OpenMenu");
		if (Input.GetKeyDown (KeyCode.LeftShift))
			anim.SetTrigger ("HideMenu");
	}
}
