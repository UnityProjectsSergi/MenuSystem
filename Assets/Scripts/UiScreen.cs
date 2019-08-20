using System;
using UnityEngine;
using UnityEngine.Events;
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
    [FormerlySerializedAs("FadeInTime")] public float fadeInTime;
    [FormerlySerializedAs("FadeOutTime")] public float fadeOutTime;
    public bool isClosed;
    public bool isOpen;
    [FormerlySerializedAs("ScreenType")] public ScreenType screenType;

    [FormerlySerializedAs("TimeFromBlack")]
    public float timeFromBlack, timeToBlack;

    private void Start()
    {
        canvas=GetComponent<UiFader>();
    }

    public  void OpenScreen(UnityAction mm)
    {
        if (screenType == ScreenType.FadeInFromBlack || screenType == ScreenType.FadeInOutBlack)
            canvas.FadeIn(fadeInTime, timeFromBlack);
        else if (screenType == ScreenType.FadeIn || screenType == ScreenType.FadeInOut)
            canvas.FadeIn(fadeInTime);
        else
            canvas.FadeIn();
    }


    public  void CloseScreen()
    {
       
            if (screenType == ScreenType.FadeOutToBlack || screenType == ScreenType.FadeInOutBlack)
            {
                Debug.Log("fade thi black close");
                canvas.FadeOut(fadeInTime, timeToBlack);
            }
            else if (screenType == ScreenType.FadeOut || screenType == ScreenType.FadeInOut)
            {
                canvas.FadeOut(fadeOutTime);
            }
            else
            {
                canvas.FadeOut();
            }

    
        // }
    }
}