using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class popup : MonoBehaviour
{
    public GameObject muncul;
    public bool aktif;
    public CanvasGroup mainMenuPanel, selectMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMouseDown()
    {
        muncul.SetActive(aktif);
    }
    public void tekanbuttonplay()
    {
        StartCoroutine(FadeOut(mainMenuPanel, 0.5f));
        StartCoroutine(FadeIn(selectMenuPanel, 0.5f));
    }
    public IEnumerator FadeIn(CanvasGroup container, float duration)
    {
        container.interactable = false;
        container.gameObject.SetActive(true);
        container.alpha = 0f;
        yield return new WaitForSeconds(0);
        container.DOFade(1f, duration).SetUpdate(true);
        container.interactable = true;
    }

    public IEnumerator FadeOut(CanvasGroup container, float duration)
    {
        container.interactable = false;
        container.alpha = 1f;
        container.DOFade(0f, duration).SetEase(Ease.InQuint).SetUpdate(true);
        yield return new WaitForSecondsRealtime(duration);
        container.gameObject.SetActive(false);
        container.interactable = true;
    }
}
