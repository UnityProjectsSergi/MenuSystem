using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiFader : MonoBehaviour
{
    public bool CanOpenNextScreen;
    public bool FadeFromBlack;
    public bool FadeToBlack;
    public CanvasGroup uiElement;
    public CanvasGroup uiFaderBlack;

    private void Awake()
    {
        uiElement = GetComponent<CanvasGroup>();
    }

    public void FadeIn(UnityAction unity = null, float timeFadeIn = 1, bool isOnFadeInOutToBlack = false,
        float fadeFromBack = 0.0f)
    {
        if (!isOnFadeInOutToBlack)
            StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 1, timeFadeIn, unity));
        else
            StartCoroutine(FadeInBlack(timeFadeIn, fadeFromBack, unity));
    }


    public IEnumerator FadeInBlack(float timeFadeIn, float fadeFromBlack, UnityAction action = null)
    {
        Coroutine fade = StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 1, timeFadeIn));
        yield return fade;
        
        action?.Invoke();
        
        Coroutine black = StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 0, fadeFromBlack));
        yield return black;
    }

    public IEnumerator FadeOutBlack(float timeFadeOut, float fadeToBlack)
    {
        Coroutine black = StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 1, fadeToBlack));
        yield return black;

        Coroutine fade = StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 0, timeFadeOut));
        yield return fade;
    }

    public void FadeOut(float timeFadeOut = 1, bool IsBlackFadeAoutInfloat = false, float fadeToBlack = 0.0f)
    {
        if (!IsBlackFadeAoutInfloat)
            StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 0, timeFadeOut));
        else
            StartCoroutine(FadeOutBlack(timeFadeOut, fadeToBlack));
    }


    public void Reset()
    {
        uiElement.alpha = 0;
        uiElement.blocksRaycasts = false;
        uiElement.interactable = false;
    }

    public void ActivateCanvasGroup()
    {
        uiElement.blocksRaycasts = true;
        uiElement.interactable = true;
    }

    public void DeactivateCanvasGroup()
    {
        uiElement.blocksRaycasts = false;
        uiElement.interactable = false;
    }
}

public class FadeEffect : MonoBehaviour
{
    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration,
        UnityAction action = null)
    {
        // keep track of when the fading started, when it should finish, and how long it has been running&lt;/p&gt; &lt;p&gt;&a
        var startTime = Time.time;
        var endTime = Time.time + duration;
        var elapsedTime = 0f;

        // set the canvas to the start alpha – this ensures that the canvas is ‘reset’ if you fade it multiple times
        canvas.alpha = startAlpha;
        // loop repeatedly until the previously calculated end time
        while (Time.time <= endTime)
        {
            elapsedTime = Time.time - startTime; // update the elapsed time
            var percentage = 1 / (duration / elapsedTime); // calculate how far along the timeline we are
            if (startAlpha > endAlpha) // if we are fading out/down 
            {
                canvas.alpha = startAlpha - percentage; // calculate the new alpha
            }
            else // if we are fading in/up
            {
                canvas.alpha = startAlpha + percentage; // calculate the new alpha
           
            }

            yield return new WaitForEndOfFrame(); // wait for the next frame before continuing the loop
        }

        
        canvas.alpha =
            endAlpha; // force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
        action?.Invoke();
    }
}