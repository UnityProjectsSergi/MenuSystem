using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFader : MonoBehaviour
{
    public CanvasGroup uiElement;
    public CanvasGroup uiFaderBlack;
    public bool CanOpenNextScreen;
    public bool FadeToBlack;
    public bool FadeFromBlack;

    private void Awake()
    {
        uiElement = GetComponent<CanvasGroup>();
    }

    public void FadeIn(float timeFadeIn=1,float fadeFromBack=0.0f)
    {

      if(fadeFromBack<=0.0f)
        StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 1, timeFadeIn));
        
      else
      {
          uiFaderBlack.alpha = 1;
          StartCoroutine(FadeInBlack(timeFadeIn,fadeFromBack));
      }
            
    }

    public IEnumerator FadeInBlack(float timeFadeIn,float fadeFromBlack)
    {
      
        Coroutine fade = StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 1, timeFadeIn));
        
        yield return fade;
        Coroutine black=StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 0, fadeFromBlack));
      
        
        yield return black;
/*        
        yield return StartCoroutine(FadeCanvasGroup(uiFaderBlack, uiFaderBlack.alpha, 0, 2f));
     yield return  StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, timeFadeIn));
        */

    }
    public IEnumerator FadeOutBlack(float timeFadeOut,float fadeToBlack)
    {
        Debug.Log("fade in black fade out scren");
      Coroutine black=StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha,1 , fadeToBlack));
       
        
        yield return black;  
    
      Coroutine fade = StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha,0 , timeFadeOut));
      yield return fade;
        
/*        yield return StartCoroutine(FadeCanvasGroup(uiFaderBlack, uiFaderBlack.alpha, 0, 2f));
     yield return  StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, timeFadeIn));
        */

    }
    public void FadeOut(float timeFadeOut=1,float fadeToBlack=0.0f)
    {
        if(fadeToBlack<=0.0f)
        StartCoroutine(FadeEffect.FadeCanvas(uiElement, uiElement.alpha, 0, timeFadeOut));
     
      else
        {
            Debug.Log(("fade ut black and scren fade in"+fadeToBlack));
           // StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 1, fadeToBlack));
          //  StartCoroutine(FadeEffect.FadeCanvas(uiFaderBlack, uiFaderBlack.alpha, 1, timeFadeOut));
            StartCoroutine(FadeOutBlack(timeFadeOut,fadeToBlack));
        }
    }

 

//    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
//    {
//        if (lerpTime <= 0) throw new ArgumentOutOfRangeException(nameof(lerpTime));
//        float timeStartedLerping = Time.time;
//        float timeSinceStarted = Time.time - timeStartedLerping;
//        float percentageComplete = timeSinceStarted / lerpTime;
//
//        while (true)
//        {
//            timeSinceStarted = Time.time - timeStartedLerping;
//            percentageComplete = timeSinceStarted / lerpTime;
//
//            float currentValue = Mathf.Lerp(start, end, percentageComplete);
//
//            cg.alpha = currentValue;
//           // Debug.Log(percentageComplete+"percent");
//            if (percentageComplete >= 1) {
//                    
//                CanOpenNextScreen = true;
//                break;
//            }
//
//            yield return new WaitForFixedUpdate();
//        }
//
//    }
}

public class FadeEffect : MonoBehaviour
{
    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
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
    }
}