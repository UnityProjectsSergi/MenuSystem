using System;
using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables

    #region Public Varales

    [HideInInspector] public GameSlot slot;
    /// <summary>
    /// System UI
    /// </summary>
    public UiSystem system;

    /// <summary>
    /// 
    /// </summary>
    //private MainMenu_KeyboardController keyboardController;
    // Use this for initialization
    public  MainMenuController mainMenuController = null;
    /// <summary>
    /// Is th Sreen GamePlayScreen
    /// </summary>
    public UiScreen GamePlayScreen;

    public UiScreen MainMenuScreen;
    public UiScreen ScreenLoading;
    public LoadScreenController LoadScreencontroller;
    public bool isgamePlay;
    #endregion

    #region Private Variables

    [SerializeField]
    /// <summary>
    /// Is The quesyion Modal Screen
    /// </summary>
    private UiScreen questionScreen;

    [SerializeField]
    /// <summary>
    /// Is The Pause Menu Screen same GameObject as Main Menu Screen 
    /// </summary>
    private UiScreen IsLoadingScreen;

    /// <summary>
    /// Unity Events to answer the Modal Question Screen
    /// </summary>
    private UnityEvent Yes, No;

    /// <summary>
    /// Delault Game Slot 
    /// </summary>

    public InfoSlotResume defaultSlot;
  

    [HideInInspector] public SlotController slotController;
    [HideInInspector] public PauseController pauseController;
  

    #endregion

    #endregion

    #region Unity Methods

    /// <summary>
    /// Iniitialize GameController
    /// </summary>
    void Awake()
    {
        pauseController = GetComponent<PauseController>();
        //Get Component UI_System
        slotController = GetComponent<SlotController>();
        //  mainMenuController = PauseMenuScreen.GetComponent<MainMenuController>();
        // system = GetComponent<UiSystem>();
        // set variable isPaus

        // for have Menu Object in all scenes except if has menu in game
//        if (!system.IsInGameMenu)
//            DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Detect Keys Downof keyboard
    /// </summary>

    #endregion

    #region Helper Methods

    /// <summary>
    /// Metodh who Makes questuon Of override Current Slot if is one slot Game or if is multipleSlots Add slot to list, Set Prvoius slot, Save All, Load Scene
    /// </summary>
    public void IsUsingOneSlot()
    {
        if (slotController.isSlotsEnabled)
        {
            
            // if useManySlots is false
            if (!slotController.useManySlots)
            {
                // If has an older slot in list
                if (SaveData.objcts.Slots.Count >= 1)
                {
                    // create the UnityEvents
                    Yes = new UnityEvent();
                    No = new UnityEvent();
                    // open modal question 
                    OpenQuestioOverrideSlotIfExists();
                }
                else
                    Add_New_Slot_To_ListsSlots_Set_Previous_Slot_SaveAllSlots_LoadScene();
            }
            // is are using Many Slots
            else
            {
                //Add slot to list, Set Prvoius slot, Save All, Load Scene
                Add_New_Slot_To_ListsSlots_Set_Previous_Slot_SaveAllSlots_LoadScene();
            }
        }
        else
        {
            LoadSceneFromSlot();
        }
    }
    public void LoadSceneFromSlot()
    {
        // if its enable Loading Scene Plugin sergi
        if (GameController.Instance.settignsMenu.IsLoaderSceneWithPligun)
        {
            system.CallSwitchScreen(ScreenLoading, delegate
            {
                LoadScreencontroller.FloaderScene();
            }, true);
        }
        else
        {
            StartCoroutine(LoadSceneSync());
            system.CallSwitchScreen(GamePlayScreen);
            pauseController.AllowEnterPause = true;
            GameController.Instance.hasCurrentSlot = true;
        } 
        Inputs.Instance.SwitchActionMap("Player");
    }
    IEnumerator LoadSceneSync()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay);
        yield return async;
        GameController.Instance.CallTakeScreenShotOnDelay(1f,slotController.isSlotsEnabled);
        if (slotController.isSlotsEnabled)
        {
            GameController.Instance.CallStartSaveSlotInterval(GameController.Instance.settignsMenu.SaveIntervalSeconds);
            SaveData.LoadGameSlotData(
                SaveData.LoadFromFile<GameSlot>(GameController.Instance.currentSlotResume.FileSlot));
        }
    }
    /// <summary>
    ///  Load Scene  
    /// </summary>
    public void Loadscene()
    {
        //Set allow EnterPause to true because exit from Main Menu 
       
        // if its enable Loading Scene Plugin sergi
        if (GameController.Instance.settignsMenu.IsLoaderSceneWithPligun)
        {   system.CallSwitchScreen(ScreenLoading, delegate
            {
             
              
            }, true);
        }
        else
        {
            SceneManager.LoadSceneAsync(GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay);
            /// SwitchSreen To GamePlayScreen 
            //  system.SwitchScreen(GamePlayScreen, true,true);
        }
        Inputs.Instance.SwitchActionMap("Player");
    }
    /// <summary>
    ///  Open Modal Screen for Override Slot If Exists in the using one slot mode
    /// </summary>
    public void OpenQuestioOverrideSlotIfExists()
    {
        // Remove old Listeners from events
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        // Add Listerners
        Yes.AddListener(() => OverrideSlot());
        No.AddListener(() => NotOverrideSlot());
        //Set parameters in QuestionScreen
        questionScreen.GetComponent<QuestionSceenController>()
            .OpenModal("Override current slot because exists", "One slot game", Yes, No);
        //Switch Screen to question Screen
        system.CallSwitchScreen(questionScreen);
    }
    /// <summary>
    /// if Question OverrideSlotIfExists for mode one only slot is YES
    /// </summary>
    public void OverrideSlot()
    {
        
        if(SaveData.objcts.previousSlotLoaded!=null)
        Directory.Delete(Application.persistentDataPath + "/" + SaveData.objcts.previousSlotLoaded.FolderOfSlot, true);
        SaveData.objcts.previousSlotLoaded=null;
        SaveData.objcts.Slots.Clear();
        GameController.Save();
        
        
        //GameController.Instance.hasCurrentSlot = true;
        // add New slot to list, SetPevous Slot, Save All Slot, an LoadScen
        Add_New_Slot_To_ListsSlots_Set_Previous_Slot_SaveAllSlots_LoadScene();
    }
    /// <summary>
    /// if Question OverrideSlotIfExists for mode one only slot is NO
    /// </summary>
    public void NotOverrideSlot()
    {
        //TODO see if we need to change to main screen menu or not? becuse if we are on one slot or many slots game
        // go to previous screen 
        system.GoToPreviousScreen();
    }

    /// <summary>
    ///  add New slot to list, SetPevous Slot, Save All Slot, an LoadScen
    /// </summary>
    public void Add_New_Slot_To_ListsSlots_Set_Previous_Slot_SaveAllSlots_LoadScene()
    {
        // add temp slot into list of data 
        SaveData.objcts.Slots.Add(GameController.Instance.currentSlotResume);
        //Set previuos SlotLoaaded in data for Conitune button in main menu 
        SaveData.objcts.previousSlotLoaded = GameController.Instance.currentSlotResume;
        // Save Change in dsk
        GameController.Save();
        //load scene
        LoadSceneFromSlot();
    }

    public void QuestionLoseGameProgressIfExit()
    {
        Yes = new UnityEvent();
        No = new UnityEvent();
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        Yes.AddListener(() => YesLostGameProgressionExitGame());
        No.AddListener(() => NoLostGameProgressionContinueFromPause());
        //Set parameters in QuestionScreen
        questionScreen.GetComponent<QuestionSceenController>().OpenModal("Lost current progress?", "Are You sure want Exit Game? ", Yes, No);
        //Switch Screen to question Screen
        system.CallSwitchScreen(questionScreen);
    }

    public void QuestionLoseGameProgressIfExitGameFromPause()
    {
        Yes = new UnityEvent();
        No = new UnityEvent();
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        Yes.AddListener(() => YesLostGameProgressionFromPause());
        No.AddListener(() => NoLostGameProgressionContinueFromPause());
        //Set parameters in QuestionScreen
        questionScreen.GetComponent<QuestionSceenController>().OpenModal("Lost current progress?", "Are You sure want Main Menu? ", Yes, No);
        //Switch Screen to question Screen
        system.CallSwitchScreen(questionScreen);
    }

    public void YesLostGameProgressionFromPause()
    {
        system.ResetListPrevScreens();
        Inputs.Instance.SwitchActionMap("UI");
        GameController.Instance.currentSlot = null;
        GameController.Instance.currentSlotResume = null;
        GameController.Instance.hasCurrentSlot = false;
        mainMenuController.SetMainMenuWithSlots();
        pauseController.isPausedGame = false;
        pauseController.AllowEnterPause = false;
        GameController.Instance.CallStopSaveSlotInterval();
        system.CallSwitchScreen(mainMenuController.GetComponent<UiScreen>());
    }

    public void YesLostGameProgressionExitGame()
    {
        GameController.Instance.CallStopSaveSlotInterval();
        GameController.Instance.hasCurrentSlot = false;
        Application.Quit();
    }

    public void NoLostGameProgressionContinueFromPause()
    {
        GameController.Instance.CallStartSaveSlotInterval(GameController.Instance.settignsMenu.SaveIntervalSeconds);
        system.CallSwitchScreen(MainMenuScreen );
    }

    #endregion
}