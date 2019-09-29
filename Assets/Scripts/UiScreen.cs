using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public enum ScreenType
{
    Normal,
    FadeIn,
    FadeOut,
    FadeInOut,
    FadeInFromBlack,
    FadeOutToBlack,
    FadeInOutBlack
}

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(UiFader))]
public class UiScreen : MonoBehaviour
{
    public UiFader canvas;
    public float fadeInTime;
    public float fadeOutTime;


    public float timeFromBlack, timeToBlack;

    private void Awake()
    {
        canvas = GetComponent<UiFader>();
    }

    public void OpenScreen(UnityAction mm = null, bool FadeInOutBlack = false)
    {
        canvas.FadeIn(mm, fadeInTime,FadeInOutBlack, timeFromBlack);
        canvas.ActivateCanvasGroup();
       
    }

    public void Reset()
    {
        canvas.Reset();
    }

    public void CloseScreen(bool fadeInOutBlack)
    {
       canvas.FadeOut(fadeOutTime,fadeInOutBlack,timeToBlack);
        canvas.DeactivateCanvasGroup();
    }
}