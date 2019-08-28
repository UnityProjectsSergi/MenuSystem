﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {
    [Header("Pause Varriables")]
    /// <summary>
    /// Says if stay in Main Menu (false) So there's no allow enter to pause menu and when its (true) can open and close pause menu   
    /// </summary>
    public bool AllowEnterPause;
    /// <summary>
    ///  Says if Stay in pause menu or Gameplay Screens
    /// </summary>
    public bool isPausedGame;
    /// <summary>
    /// KeyCode for going Back Screen in Pause Menu Screens and Main Menu Screens, and to Enter and exit into Pause Menu Screen frim GamePlay Screen 
    /// </summary>
    public KeyCode backKeyInMenuAndPauseUnpause = KeyCode.Escape;
    /// <summary>
    /// Is th Sreen GamePlayScreen
    /// </summary>
    public UiScreen GamePlayScreen;
   

    [SerializeField]
   private MainMenuController mainMenuController;
    /// <summary>
    /// Is The Pause Menu Screen same GameObject as Main Menu Screen 
    /// </summary>
    
    private UiSystem system;
    // Use this for initialization
    public float TimeBetweenPause=1f;
    private float timer;
    void Awake () {

    }
    private void Start()
    {

        //mainMenuController = GetComponent<MainMenuController>();
//        system = GetComponent<UISystem>();
        isPausedGame = false;
       
    }
    // Update is called once per frame
    void Update () {
		
	}
    /// <summary>
    /// Detect Keys Downof keyboard
    /// </summary>
    private void OnGUI()
    {
        // if AllowEnterPause is true
        if (AllowEnterPause)
        {
            Event e = Event.current;
           
            // if Event.current is Key and the keycode is backKeyInMenuAndPauseUnpause and Event Type is KeyDown
            if (Time.time >= timer && e.isKey && e.keyCode == backKeyInMenuAndPauseUnpause && e.type == EventType.KeyDown)
            {
                // if game is Paused
                if (isPausedGame)
                {
                    // if current Screen is not Pause Menu 
                    
                    if (!system.CurrentScreen.Equals(mainMenuController.GetComponent<UiScreen>()))
                    {
                        // go to previuos screen inside pause menu
                        system.GoToPreviousScreen();
                    }
                    // if current Screen is Pause Menu
                    else
                    {
                        // switch screen to GamePlay Screen
                        system.CallSwitchScreen(GamePlayScreen,null,false);
                        // set false to IsPausedGeme to unpause the game
                        isPausedGame = false;
                    }
                }
                // if not paused game so i'm in gameplay
                else
                {
                    //call setpausemenu on mainmenu to set the buttons for pauseMenu
//                    mainMenuController.mainMenuButtons.SetPauseMenu();
//                    // switchSreen to Pause Menu Screen
//                    system.SwitchScreen(mainMenuController.gameObject.GetComponent<UI.UI_Screen>(),false);
                    // set true to isPausedGame to pause the game
                    isPausedGame = true;
                }
                    timer = Time.time + TimeBetweenPause;
            }
        }
    }
}
