using System;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
    public GameObject SetSelected;
    public UiFader canvas;
    public float fadeInTime;
    public float fadeOutTime;

    public List<GameObject> IUElements;

    public float timeFromBlack, timeToBlack;

    private void Awake()
    {
        canvas = GetComponent<UiFader>();
        IUElements=new List<GameObject>();
        
    }

    
    public void EnableDisableUiElements(bool flag)
    {
        if(IUElements.Count>0)
        foreach (GameObject Item in IUElements)
        {
            Item.GetComponent<Selectable>().interactable = flag;
        }
    }
    public void OpenScreen(UnityAction mm = null, bool FadeInOutBlack = false)
    {
        EnableDisableUiElements(true);
        canvas.FadeIn(mm, fadeInTime,FadeInOutBlack, timeFromBlack);
        canvas.ActivateCanvasGroup();
        if(SetSelected!=null)
        EventSystem.current.SetSelectedGameObject(SetSelected);
        
    }

    public void Reset()
    {
        canvas.Reset();
    }

    public void CloseScreen(bool fadeInOutBlack)
    {
       canvas.FadeOut(fadeOutTime,fadeInOutBlack,timeToBlack);
        canvas.DeactivateCanvasGroup();
        EnableDisableUiElements(false);
    }
}