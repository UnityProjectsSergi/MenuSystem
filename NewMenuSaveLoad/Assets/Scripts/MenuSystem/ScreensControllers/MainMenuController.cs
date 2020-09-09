using System;
using Assets.SaveSystem1.DataClasses;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
   
    [Header("Screens")]
    
    
    public UiScreen DificultSelectionScreen;

    public UiScreen OwnScreen;
    /// <summary>
    /// 
    /// </summary>
    public UiScreen LevelSelectionScreen;
    public UiScreen GamePlayScreen;
  
    /// <summary>
    ///  Screen
    /// UIScreen Load Slot List
    /// </summary>
    public UiScreen LoadSlotListScreen;
   public UiScreen Options;
    public UiScreen SaveGameScreen;
    /// <summary>
    ///     Script
    ///     Main Menu Buttons To change from Main menu to Pause Menu
    /// </summary>
    public MainMenuButtons MainMenuButtons;

    /// <summary>
    ///     Controller
    ///     Menu Controller
    /// </summary>
    public MenuController MenuController;

 
    private InfoSlotResume slot;
    public string LevelNameToLoadInDefaults;
    [Header("Controllers")]
    /// <summary>
    /// Controller
    /// Slot Controller
    /// </summary>
    public SlotController SlotController;

    /// <summary>
    ///     Ui System
    ///     System For UI
    /// </summary>
    public UiSystem UiSystem;

    public void InirMainMenuData()
    {
        OwnScreen = GetComponent<UiScreen>();
        //Initialize menuController variable
        if (MenuController == null) MenuController = MenuController.GetComponent<MenuController>();
        if (SlotController == null)
            SlotController = MenuController.GetComponent<SlotController>();
        // Initialize UI system variable
        
        // if has loaded data from file
        if (GameController.hasLoadedGameData) SetMainMenuWithSlots();   
    }
    
    // Start is called before the first frame update
    private void Start()
    {
       if(!GameController.Instance.globalSettignsMenu.isUserLoginRegisterActive)
           InirMainMenuData();
    
    }


    // Update is called once per frame
    private void Update()
    {
       
    }

    public void NewGame()
    {
        // create new slot Redume
        slot = new InfoSlotResume(DateTime.Now);
        slot.CrateFolder();
        // set new slot to currentSlot
        GameController.Instance.currentSlotResume = slot;
        GameController.Instance.currentSlot=new GameSlot();
        GameController.Instance.hasCurrentSlot = true;
        /// if menu have isLevelSelectonScreenEnabled true 
        if (GameController.Instance.globalSettignsMenu.isLevelSelectonScreenEnabled)
        {
            // Switch screen to levelSelection Screen
            UiSystem.CallSwitchScreen(LevelSelectionScreen);
        }
        /// if menu have isLevelSelectonScreenEnabled false
        else
        {
            // if menu have isDificultyLevelSelectionScreenEnabled true 
            if (GameController.Instance.globalSettignsMenu.isDificultyLevelSelectionScreenEnabled)
            {
                /// if menu have isLevelSelectonScreenEnabled true
                UiSystem.CallSwitchScreen(DificultSelectionScreen);
            }
            // if menu have isDificultyLevelSelectionScreenEnabled false 
            else
            {
                
                GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay = LevelNameToLoadInDefaults;
                //Pass to using One or many Slots
                MenuController.IsUsingOneSlot();
            }
        }
    }
    /// <summary>
    /// Button Continue on Main Menu
    /// Only active if has a Savedata.objects.previousSlotLoaded es not null
    /// </summary>
    public void ContinueClickBtn()
    {
        // Load the previous Slot Loadded in current Sloy
        GameController.Instance.currentSlotResume = SaveData.objcts.previousSlotLoaded;
        // laod screeneFrom Slot 
        MenuController.LoadSceneFromSlot();
      
        GameController.Instance.hasCurrentSlot = true;
    }
    /// <summary>
    ///  Button Exit to Main Menu From Pause Menu
    ///  Only Active if Stay in Pause Menu
    /// </summary>
    public void ExitToMainMenuFromMenuPause()
    {
        // Open question From Pause Menu Exit Game
        MenuController.QuestionLoseGameProgressIfExitGameFromPause();
    }
    /// <summary>
    /// Button Exit Game 
    /// </summary>
    public void ExitGame()
    {
        // if stay in Pause Menu has the currentSlot Resume not null
        if (GameController.Instance.hasCurrentSlot)
            // Open question LoseGame progess if exit
            MenuController.QuestionLoseGameProgressIfExit();
        else
            // If estay en Main menu Exit Game
                 Debug.Log("exit game");
            Application.Quit();
    }
    /// <summary>
    /// Button Resume Game
    /// Only active on Pause Menu
    /// </summary>
    public void ResumeGame()
    {
        // set is Pause to False
        
        MenuController.pauseController.isPausedGame = false;
        
        UiSystem.CallSwitchScreen(MenuController.GamePlayScreen);
    }
    /// <summary>
    /// Button Load Game
    /// Active on Pause and Main Menu if has slots to load
    /// </summary>
    public void LoadGame()
    {
        LoadSlotListScreen.GetComponent<LoadSlotListController>().GenerateSlots();
        UiSystem.CallSwitchScreen(LoadSlotListScreen);
    }
    /// <summary>
    /// Button Open Settings
    ///  Active in Both Menus
    /// </summary>
    public void OpenSettings()
    {
        UiSystem.CallSwitchScreen(Options);
    }

    public void SaveGame()
    {
        if (MenuController.slotController.isSlotsEnabled)
        {
            if (MenuController.slotController.useManySlots)
            {
                SaveGameScreen.GetComponent<SaveGameController>().GenerateSlots();
                UiSystem.CallSwitchScreen(SaveGameScreen);
            }
            else
            {
                if (SaveData.objcts.Slots.Count == 0)
                {
                    slot=new InfoSlotResume(DateTime.Now);
                    slot.CrateFolder();
                    SaveData.objcts.Slots.Add(slot);
                    GameController.Instance.currentSlotResume = slot;
                    GameController.Instance.currentSlot = slot.slotGame;
                    GameController.Instance.hasCurrentSlot = true;
                    SaveData.objcts.previousSlotLoaded = slot;
                }
                else
                {
                    GameController.Instance.currentSlotResume.dataInfoSlot.datetimeSaved = DateTime.Now;
                }

                GameController.SaveSlotObj();
                // Save Change in dsk
                GameController.SaveGame();
                GameController.Instance.pauseController.isPausedGame = false;
                UiSystem.CallSwitchScreen(GamePlayScreen, delegate { GamePlayScreen.GetComponent<GamePlayScreenController>().ShowImageSavedGame(); });
           
            }
        }
    }

    public void SetMainMenuWithSlots()
    {
        
        // Active Main Menu Buttons
        MainMenuButtons.SetMainMenu(MenuController.slotController,SaveData.objcts.Slots.Count);
        // if not have slots in list
        if (SaveData.objcts.previousSlotLoaded == null)
        {
            // Set selected the New Game Button 
            EventSystem.current.SetSelectedGameObject(MainMenuButtons.NewGameBtn.gameObject);
            MainMenuButtons.ContinueBtn.gameObject.SetActive(false);
            OwnScreen.defaultUiElementSelected = MainMenuButtons.NewGameBtn.gameObject;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(MainMenuButtons.ContinueBtn.gameObject);
            OwnScreen.defaultUiElementSelected = MainMenuButtons.ContinueBtn.gameObject;
        }
    }

    public void SetPauseMenuwithSlots()
    {
        EventSystem.current.SetSelectedGameObject(MainMenuButtons.ResumeBtn.gameObject);
        MainMenuButtons.SetPauseMenu(MenuController.slotController,SaveData.objcts.Slots.Count);
        OwnScreen.defaultUiElementSelected = MainMenuButtons.ResumeBtn.gameObject;
    }
}