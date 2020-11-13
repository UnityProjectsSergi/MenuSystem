using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class UiSystem : MonoBehaviour
{
    
    #region Variables In GameMenu

    

    #endregion
    [Header(
        "To put IN GAME MENU mode have to put all canvas in world space Render Mode and have more than 1 Canvas inside of UiSystem gameObj Script  ")]
    [Header("InGameMenu Properites")]
    /// <summary>
    /// bool indicates is IN Game Menu with moviment of camera and only have one unity scene because the menu is ingame.
    /// </summary> 
    public bool IsInGameMenu;

    [SerializeField]
    /// <summary>
    /// bool indicates the movement of the camera is lerped
    /// </summary>
    private bool LerpMovimentCaamera;
    [SerializeField]

    private Camera mainCamera;
    private Transform OrinTranform;
    private Canvas currentCanvas;
    private Canvas previousCanvas;
    
    public static bool CanOpenNextScreen = true;
    public bool canSwitchScreenPreventMultipleCalls;
    

    [SerializeField]
    /// <summary>
    /// privte currentScreeen
    /// </summary>
    private UiScreen currentScreen;

    public List<Canvas> listPrevCanvas;
    public List<UiScreen> listPrevScreens;
    public int numPrvevScreen;
    public Color BGScreensColor;
    private UiScreen previousScreen;
    public bool SavePathOfScreensToGoPrev;

    // Start is called before the first frame update
    private Component[] screens = new Component[0];

    // Start is called before the first frame update
    public UiScreen startScreen;

    /// <summary>
    /// public Previuos Screen
    /// </summary>
    public UiScreen PreviousScreen
    {
        get { return previousScreen; }
    }

    /// <summary>
    /// public currrent screen
    /// </summary>
    [SerializeField]
    public UiScreen CurrentScreen
    {
        get { return currentScreen; }
    }
    [Tooltip("If has Settings Global active the register and login on start go to this screen")]
    public UiScreen OnStartScreenOnLoginRegisterActive;
    public bool isFirstEnter;
    // Start methodth
    private void Awake()
    {
        
        
    }

    private void OnEnable()
    {
        
    }

    void Start()
    {
        if (GameController.Instance.globalSettignsMenuSC.loginRegisterSettings.isUserLoginRegisterActive)
        {
            startScreen = OnStartScreenOnLoginRegisterActive;
        }
        // set number of Previous Screen index to 0
        numPrvevScreen = 0;
        // get Child UiScreens components 
        screens = GetComponentsInChildren<UiScreen>(true);
        // if SavePath of screens to go previous screens 
        if (SavePathOfScreensToGoPrev)
            listPrevScreens = new List<UiScreen>();
        // initialize screens
        InitiaizeScreens();
        // if isFirstEnter es false and startScreen es setted
        if (!isFirstEnter && startScreen  )
        {
            isFirstEnter = true;
            
            // call SwitchScreen Coroutine
            StartCoroutine(SwitchScreen(startScreen));
        }
    }
    /// <summary>
    /// Initialize screens
    /// </summary>
    private void InitiaizeScreens()
    {
        //loop all screens 
        foreach (UiScreen screen in screens)
        {
            // Reset the canvas Group components alfa raycast and interactuable
            screen.Reset();
            // set buttons of screens to disable for selection feature
            screen.EnableDisableUiElements(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
       
    }
    /// <summary>
    /// Public SwiychScreen Methodh
    /// </summary>
    /// <param name="newScreen">New Screen to Open</param>
    /// <param name="Action">Action to do inside of switch screen</param>
    /// <param name="fadeToBlack">say if needs to fade to black screen</param>
    /// <param name="timeInFadeBlack">Time of </param>
    /// 
    public void CallSwitchScreen(UiScreen newScreen, UnityAction Action = null, bool fadeToBlack = false,
        float timeInFadeBlack=0.0f)
    
    {
        //  check if canSwitch Screen es true  to prevent the multiple calls of switch screen
        if (canSwitchScreenPreventMultipleCalls)
            StartCoroutine(SwitchScreen(newScreen, Action, fadeToBlack,timeInFadeBlack));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newScreen"></param>
    /// <param name="Action"></param>
    /// <param name="fadeInOutBlack"></param>
    /// <param name="timeToWaitSwitchScreen"></param>
    /// <returns></returns>
    private IEnumerator SwitchScreen(UiScreen newScreen, UnityAction Action = null, bool fadeInOutBlack = false,
        float timeToWaitSwitchScreen=0.0f)
    {
        // if there new screen
        if (newScreen)
        {
            // desable the can SwitchScreenPreventMultiple calls
            canSwitchScreenPreventMultipleCalls = false;
            //if SavePathofScreensToGoPrev is true
            if (SavePathOfScreensToGoPrev)
            {
                // ad newScreen in list of PreviousScreens
                listPrevScreens.Add(newScreen);
                numPrvevScreen++;
            }
            // if has value currentScreens
            if (currentScreen)
            {
                // close currecntScreens
                currentScreen.CloseScreen(fadeInOutBlack);
                //if SavePathofScreensToGoPrev is false
                if (!SavePathOfScreensToGoPrev)
                    // set the previuosScreen with currentScreen
                    previousScreen = currentScreen;
            }
            // wat for timeToWaitSwitchScreen
            yield return new WaitForSeconds(timeToWaitSwitchScreen);
            // set currentScreen with newScreen
            currentScreen = newScreen;
            // open current screen
            currentScreen.OpenScreen(Action, fadeInOutBlack);
            // enable the can SwitchScreenPreventMultiple calls
            canSwitchScreenPreventMultipleCalls = true;
        }
    }
    /// <summary>
    ///  Switch screen to go previous screen
    /// </summary>
    /// <param name="aScreen"></param>
    /// <param name="nae"></param>
    /// <param name="fadeToBlack"></param>
    /// <returns>IEnumerator Coroutine</returns>
    public IEnumerator SwitchScreenPrev(UiScreen aScreen, UnityAction nae = null, bool fadeToBlack = false,float timeToWaitSwitchScreen=0.0f)
    {
        //if pass an screen
        if (aScreen)
        {
            // desable the can SwitchScreenPreventMultiple calls
            canSwitchScreenPreventMultipleCalls = false;
            // if current screen is set
            if (currentScreen)
            {
               // Close current canvas
                currentScreen.CloseScreen(fadeToBlack);
                // set previousScreen with currentScreen
            }

            yield return new WaitForSeconds(timeToWaitSwitchScreen);
            //set currentScreen with newScren
            currentScreen = aScreen;
            //Open currentScreen
            currentScreen.OpenScreen(nae, fadeToBlack);
            // enable the can SwitchScreenPreventMultiple calls
            canSwitchScreenPreventMultipleCalls = true;
        }
    }

    public void GoToPreviousScreen()
    {
        // desable the can SwitchScreenPreventMultiple calls
        if(canSwitchScreenPreventMultipleCalls){
            //if SavePathofScreensToGoPrev is true
        if (SavePathOfScreensToGoPrev)
        {
            //if number Of Screens Previous is major than1
            if (numPrvevScreen > 1)
            {
                // reduce the number of Prev Screens
                numPrvevScreen--;
                // get prevoius screen from list
                previousScreen = listPrevScreens[numPrvevScreen - 1];
                //remove
                listPrevScreens.RemoveAt(numPrvevScreen);
                // call SwitchScreen
                StartCoroutine(SwitchScreenPrev(previousScreen));
            }
        }
        else
        {
            // is has previous Screen set
            if (previousScreen)
            {
                // call SwitchScreenPrev  Corourtine
                StartCoroutine(SwitchScreenPrev(previousScreen));
            }
        }
    }

       
}

    public void ResetListPrevScreens()
    {
        listPrevScreens.Clear();
        numPrvevScreen = 0;

    }
    
}