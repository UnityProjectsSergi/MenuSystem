using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SaveSystem1.DataClasses;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Interactions;

public class MainMenuController : MonoBehaviour
{
    public UiScreen LoadSlotListScreen;
    public SlotController SlotController;
    public MainMenuButtons MainMenuButtons;
    public MenuController MenuController;
 
    public UiSystem UiSystem;
    public UiScreen Options;
    public UiScreen SaveGameScreen;
  
    // Start is called before the first frame update
    void Start()
    {
        //Initialize menuController variable
        if (MenuController == null)
        {
            MenuController = MenuController.GetComponent<MenuController>();
         
        }
        if(  SlotController==null)
            SlotController = MenuController.GetComponent<SlotController>();
        // Initialize UI system variable
       
        // if has loaded data from file
        if (GameController.hasLoadedGameData)
        {
            SetMainMenuWithSlots();    
        }
      
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        slot = new InfoSlotResume(DateTime.Now);
        slot.CrateFolder();
        // set new slot to currentSlot
        GameController.Instance.currentSlotResume = slot;
        /// if menu have isLevelSelectonScreenEnabled true 
        if (MenuController.isLevelSelectonScreenEnabled)
        {
            // Switch screen to levelSelection Screen
            UiSystem.CallSwitchScreen(LevelSelectionScreen);
        }
        /// if menu have isLevelSelectonScreenEnabled false
        else
        {
            // if menu have isDificultyLevelSelectionScreenEnabled true 
            if (MenuController.isDificultyLevelSelectionScreenEnabled)
            {
                /// if menu have isLevelSelectonScreenEnabled true
                UiSystem.CallSwitchScreen(DificultSelectionScreen);
            }
            // if menu have isDificultyLevelSelectionScreenEnabled false 
            else
            {
                GameController.Instance.currentSlotResume.currentLevelPlay = LevelNameToLoadInDefaults;
                //Pass to using One or many Slots

                MenuController.IsUsingOneSlot();
            }
        }
    }

    public string LevelNameToLoadInDefaults;

    public UiScreen DificultSelectionScreen;

    public UiScreen LevelSelectionScreen;
    private InfoSlotResume slot;
    public void ContinueClickBtn()
    {
        GameController.Instance.currentSlotResume = SaveData.objcts.previousSlotLoaded;
        MenuController.LoadSceneFromSlot();
    }
    public void ExitToMainMenuFromMenuPause()
    {
        MenuController.QuestionLoseGameProgressIfExitGameFromPause();
    }
    public void ExitGame()
    {
        if ((bool)GameController.Instance.currentSlotResume)
            MenuController.QuestionLoseGameProgressIfExit();
        else
            Application.Quit();
    }
    public void ResumeGame()
    {
        MenuController.pauseController.isPausedGame  = false;
        UiSystem.CallSwitchScreen(MenuController.GamePlayScreen);
    }
    public void LoadGame()
    {
        LoadSlotListScreen.GetComponent<LoadSlotListController>().GenerateSlots();  
        UiSystem.CallSwitchScreen(LoadSlotListScreen);
        
    }
    public void OpenSettings()
    {
        UiSystem.CallSwitchScreen(Options,null,false);
    }

    public void SaveGame()
    {
        SaveGameScreen.GetComponent<SaveGameController>().GenerateSlots();
        UiSystem.CallSwitchScreen(SaveGameScreen);
    }
    public void SetMainMenuWithSlots()
    {
        // Active Main Menu Buttons
       
        MainMenuButtons.SetMainMenu();
        // if not have slots in list
        if (MenuController.slotController.isSlotsEnabled)
        {
            // If no has slots count
            if (SaveData.objcts.Slots.Count == 0)
            {
                // No activate LoadGmeBtn and 
                   MainMenuButtons.LoadGameBtn.gameObject.SetActive(false);
            }
            // if have slot or slots in list
            else if (SaveData.objcts.Slots.Count >= 1)
            {
                // use One Only Slot is true
                if (!MenuController.slotController.useManySlots)
                {
                    // No activate LoadGameBtn
                    MainMenuButtons.LoadGameBtn.gameObject.SetActive(false);
                }
            }           
        }
        else
        {
            MainMenuButtons.LoadGameBtn.gameObject.SetActive(false);
        }
        if (SaveData.objcts.previousSlotLoaded == null)
        {
            EventSystem.current.SetSelectedGameObject(MainMenuButtons.NewGameBtn.gameObject);
            MainMenuButtons.ContinueBtn.gameObject.SetActive(false);
        }
    }
}
