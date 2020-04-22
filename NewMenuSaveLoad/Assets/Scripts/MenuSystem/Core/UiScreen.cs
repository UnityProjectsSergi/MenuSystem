using System;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEditor;
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
    /// <summary>
    ///  Object to select when screen opens
    /// </summary>
    public GameObject defaultSelected;
    /// <summary>
    ///  Canvas and reference to UIFader script
    /// </summary>
    public UiFader canvas;
    /// <summary>
    /// time in seconds it takes fader to fade in screen
    /// </summary>
    public float openScreenFadeInTime;
    /// <summary>
    /// time in seconds it takes fader to fade out screen
    /// </summary>
    public float closeScreenFadeOutTime;
    /// <summary>
    /// List of ui elements selectables
    /// </summary>
    public List<GameObject> UiElements;
    /// <summary>
    /// 
    /// </summary>
    public float timeFromBlack, timeToBlack;
    // Awke Unity Funtion
    private void Awake()
    {
        canvas = GetComponent<UiFader>();
      UiElements=new List<GameObject>();
        
    }
    /// <summary>
    /// set interacitbe parameter the Selectable UiElements of screens
    /// </summary>
    /// <param name="flag"> Set ture or false </param>
    public void EnableDisableUiElements(bool flag)
    {
        if(UiElements.Count>0)
        foreach (GameObject Item in UiElements)
        {
            if(Item.GetComponent<Selectable>()!=null)
            Item.GetComponent<Selectable>().interactable = flag;
        }
    }
    /// <summary>
    /// Opens the screen
    /// </summary>
    /// <param name="ActionEvent">Event of Unity to invoke</param>
    /// <param name="FadeInOutBlack">say if need the fade to black</param>
    public void OpenScreen(UnityAction ActionEvent = null, bool FadeInOutBlack = false)
    {
        // Enable the Selectable Ui Elements
        EnableDisableUiElements(true);
        /// make the fade in 
        canvas.FadeIn(ActionEvent, openScreenFadeInTime,FadeInOutBlack, timeFromBlack);
        // Activate canvas varibales
        canvas.ActivateCanvasGroup();
        // set setlected the default selection
        if(defaultSelected)
        EventSystem.current.SetSelectedGameObject(defaultSelected);
        
    }

    public void Update()
    {
        Debug.Log(Selection.gameObjects.Length);
        
    }

    /// <summary>
    /// Reset valables of canvas
    /// </summary>
    public void Reset()
    {
        // reset
        canvas.Reset();
    }
    /// <summary>
    /// Close the screen 
    /// </summary>
    /// <param name="fadeInOutBlack"></param>
    public void CloseScreen(bool fadeInOutBlack)
    {
        // CALL fade out 
        canvas.FadeOut(closeScreenFadeOutTime,fadeInOutBlack,timeToBlack);
        // Desactivate canvas varibales
        canvas.DeactivateCanvasGroup();
        // Disble Ui Elements of canvas
        EnableDisableUiElements(false);
    }
}