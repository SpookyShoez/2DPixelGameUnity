using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed = 1f;

    private IEnumerator fadeInRoutine;

    public void FadeToBlack()
    {
        if (fadeInRoutine != null)
        {
            StopCoroutine(fadeInRoutine);
        }
        fadeInRoutine = FadeRoutine(1);
        StartCoroutine(fadeInRoutine);
    }

    public void FadeToClear()
    {
        if (fadeInRoutine != null)
        {
            StopCoroutine(fadeInRoutine);
        }
        fadeInRoutine = FadeRoutine(0);
        StartCoroutine(fadeInRoutine);

    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);
            yield return null;
        }
    }
}
