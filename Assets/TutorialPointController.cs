using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TutorialPointController : MonoBehaviour
{
    public TutorialPointController nextStep;
    public float activationDelay = 1f;
    private float fadeTime = 0.5f;
    public CanvasGroup cg;
    public bool startNode = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        cg.alpha = 0f;
        if(startNode)
        {
            Show();
        }
    }

    public void Hide()
    {

        cg.DOFade(0f, fadeTime);
        if (nextStep != null)
        {
            nextStep.Show();
        }
        StartCoroutine(DeactivateLater(fadeTime));
    }

    public IEnumerator DeactivateLater(float when)
    {
        yield return new WaitForSeconds(when);
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        cg.DOFade(1f, fadeTime);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
