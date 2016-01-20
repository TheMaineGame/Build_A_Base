using UnityEngine;
using System.Collections;

public class MagicAnimationScript : MonoBehaviour {

    [SerializeField] Animator CameraAnimator;
    [SerializeField] Animator CanvasAnimator;


    public void TriggerStart()
    {
        CameraAnimator.SetTrigger("DiveIn");
        CanvasAnimator.SetTrigger("GoClicked");
    }
}
