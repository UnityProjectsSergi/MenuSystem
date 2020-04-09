using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiFader : MonoBehaviour
{
    /// <summary>
    /// Canvas group when needs to make the fader
    /// </summary>
   public CanvasGroup uiElement;
    /// <summary>
    /// Canvas grioup where needs to make the fadeIn or out to black
    /// </summary>
    public CanvasGroup uiFaderBlack;
    /// <summary>
    /// Awake unity funtion
    /// </summary>
    private void Awake()
    {
        // if ui Element the CanvasGroup is null
        if(uiElement==null) 
        // get it and assinged 
        uiElement = GetComponent<CanvasGroup>();
    }
    /// <summary>
    /// FadeIn allows the fadeIn of canvas group uiElement
    /// </summary>
    /// <param name="unity"> Action to take inside of fade In</param>
    /// <param name="timeFadeIn"> Time of duration of fade IN in seconds </param>
    /// <param name="isOnFadeInOutToBlack"> if is true  Need to make the fade iN to black if ist false no needs</param>
    /// <param name="timeFadeFromBack"> Time of duration of fade IN to black in seconds</param>
    public void FadeIn(UnityAction unity = null, float timeFadeIn = 1, bool isOnFadeInOutToBlack = false,
        float timeFadeFromBack = 0.0f)
    {
        
        if (!isOnFadeInOutToBlack)
            StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 1, timeFadeIn, unity));
        else
            StartCoroutine(FadeInBlack(timeFadeIn, timeFadeFromBack, unity));
    }
    /// <summary>
    /// FadeOut allows the fadeOut of canvas group uiElement
    /// </summary>
    /// <param name="timeFadeOut">Time of duration of fade out In seconds</param>
    /// <param name="IsBlackFadeAoutInfloat">if is true  Need to make the fade Out to black if ist false no needs</param>
    /// <param name="timeFadeToBlack">Time of duration of fade Out to black in seconds</param>
    public void FadeOut(float timeFadeOut = 1, bool IsBlackFadeAoutInfloat = false, float timeFadeToBlack = 0.0f)
    {
        if (!IsBlackFadeAoutInfloat)
            StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 0, timeFadeOut));
        else
            StartCoroutine(FadeOutBlack(timeFadeOut, timeFadeToBlack));
    }
    /// <summary>
    /// Reset the alpha the bloksRaycast and the interactable variables of canvas gropu
    /// </summary>
    public void Reset()
    {
        if (uiElement != null)
        {
            uiElement.alpha = 0;
            uiElement.blocksRaycasts = false;
            uiElement.interactable = false;
        }
    }
    /// <summary>
    /// Activate the blocks Raycast and interactuable setting true
    /// </summary>
    public void ActivateCanvasGroup()
    {
        uiElement.blocksRaycasts = true;
        uiElement.interactable = true;
    }
    /// <summary>
    /// Desactivate the blocks Raycast and interactuable setting false
    /// </summary>
    public void DeactivateCanvasGroup()
    {
        uiElement.blocksRaycasts = false;
        uiElement.interactable = false;
    }
    /// <summary>
    /// FadeIn Canvas Group Screen and fade Out CanvasGroup black
    /// </summary>
    /// <param name="timeFadeIn">Time Fade In screen in seconds</param>
    /// <param name="timeFadeFromBlack">Time fade in screen black in secods</param>
    /// <param name="action">Action to make between</param>
    /// <returns>IEnumerator coroutine</returns>
    public IEnumerator FadeInBlack(float timeFadeIn, float timeFadeFromBlack, UnityAction action = null)
    {
        Coroutine fade = StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 1, timeFadeIn));
        yield return fade;
        
        action?.Invoke();
        
        Coroutine black = StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 0, timeFadeFromBlack));
        yield return black;
    }
    /// <summary>
    /// Fade Out Canvas Group Screen and Fade In CanvasGroup black
    /// </summary>
    /// <param name="timeFadeOut">Time of fade out of screen</param>
    /// <param name="timeFadeToBlack">Time of fade in the black screen</param>
    /// <returns>IEnumerator coroutine</returns>
    public IEnumerator FadeOutBlack(float timeFadeOut, float timeFadeToBlack)
    {
        Coroutine black = StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 1, timeFadeToBlack));
        yield return black;

        Coroutine fade = StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 0, timeFadeOut));
        yield return fade;
    }
}
