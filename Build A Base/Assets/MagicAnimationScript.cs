using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MagicAnimationScript : MonoBehaviour {

    [SerializeField] Animator CameraAnimator;
    [SerializeField] Animator CanvasAnimator;


    public void TriggerStart()
    {
        CameraAnimator.SetTrigger("DiveIn");
        CanvasAnimator.SetTrigger("GoClicked");
    }

    public void TriggerQuit()
    {
        CanvasAnimator.SetTrigger("QuitClicked");
        StartCoroutine(QuitCoroutine());
    }

    IEnumerator QuitCoroutine()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

    IEnumerator FakeTheLoadingScreen()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
