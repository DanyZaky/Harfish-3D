using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandbookManager : MonoBehaviour
{

    public void FadeInButton(CanvasGroup panel1)
    {
        StartCoroutine(FadeIn(panel1, 0.5f));
    }

    public void FadeOutButton(CanvasGroup panel1)
    {
        StartCoroutine(FadeOut(panel1, 0.5f));
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

    public IEnumerator SmoothFadeTransition(CanvasGroup panel1, CanvasGroup panel2, float duration)
    {
        StartCoroutine(FadeOut(panel1, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(FadeIn(panel2, duration));
    }
}
