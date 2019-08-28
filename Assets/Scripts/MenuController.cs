﻿using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables
    #region Public Varales
    /// <summary>
    /// Says if is Screen DificultyLevelSelection is Enabled (true) of Desactive (false) 
    /// </summary>
    public bool isDificultyLevelSelectionScreenEnabled;
    /// <summary>
    /// Says if is Screen Level Selection is Enabled (true) of Desactive (false) 
    /// </summary>
    public bool isLevelSelectonScreenEnabled;
    /// <summary>
    /// Is th Sreen GamePlayScreen
    /// </summary>
    public UiScreen GamePlayScreen;
    public bool IsLoaderSceneWithPligun;
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
    [HideInInspector]
    public GameSlot slot;
    /// <summary>
    /// System UI
    /// </summary>
    private UiSystem system;
    /// <summary>
    /// 
    /// </summary>
    //private MainMenu_KeyboardController keyboardController;
    // Use this for initialization
    [HideInInspector]
    private MainMenuController mainMenuController = null;
    [HideInInspector]
    public SlotController slotController;
    [HideInInspector]
    public PauseController pauseController;
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
        system = GetComponent<UiSystem>();
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
    public void LoadSceneFromSlot()
    {
        pauseController.AllowEnterPause = true;
        // if its enable Loading Scene Plugin sergi
        if (IsLoaderSceneWithPligun)
        {
            Debug.Log("Ente Strar Load scren");
           // IsLoadingScreen.GetComponent<LoadingScreenController>().StartLoadScreen(true);

        }
        else
        {

            StartCoroutine(LoadSceneSync());
        //    SceneManager.LoadSceneAsync(GameController.Instance.currentSlotResume.currentLevelPlay);
            // aixo obje el fitxer sel slot selecccionat i fa les eves coses quant la nova l'escen esta carregada
           
            //SaveData.LoadGameSlotData(SaveData.LoadFromFile<GameSlot>(GameController.Instance.currentSlotResume.FileSlot));
          //  system.SwitchScreen(GamePlayScreen, true, true);
        }/// SwitchSreen To GamePlayScreen 
    }
    IEnumerator  LoadSceneSync()
    {

     AsyncOperation async=   SceneManager.LoadSceneAsync(GameController.Instance.currentSlotResume.currentLevelPlay);
        yield return async;
        Debug.Log("loadscenesync");
        
       SaveData.LoadGameSlotData(SaveData.LoadFromFile<GameSlot>(GameController.Instance.currentSlotResume.FileSlot));
       // system.SwitchScreen(GamePlayScreen, true, true);
    }
    /// <summary>
    ///  Load Scene  
    /// </summary>
    public void Loadscene()
    {
        //Set allow EnterPause to true because exit from Main Menu 
       pauseController.AllowEnterPause = true;
        // if its enable Loading Scene Plugin sergi
        if (IsLoaderSceneWithPligun)
        {
           // IsLoadingScreen.GetComponent<LoadingScreenController>().StartLoadScreen(false);
        }
        else
        {
            SceneManager.LoadSceneAsync(GameController.Instance.currentSlotResume.currentLevelPlay);
            /// SwitchSreen To GamePlayScreen 
          //  system.SwitchScreen(GamePlayScreen, true,true);
        }
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
      // questionScreen.GetComponent<QuestionSceenController>().OpenModal("Override current slot because exists", "One slot game", Yes, No);
        //Switch Screen to question Screen
      //  system.SwitchScreen(questionScreen);
    }
    /// <summary>
    /// if Question OverrideSlotIfExists for mode one only slot is YES
    /// </summary>
    public void OverrideSlot()
    {
        // Clear the Slots list
        Debug.Log("ddd esorrara");
        SaveData.objcts.Slots.Clear();
        Debug.Log("Override Slot because useManySlots is false and answer yes so loads game with new slot");
        // add New slot to list, SetPevous Slot, Save All Slot, an LoadScen
        Add_New_Slot_To_ListsSlots_Set_Previous_Slot_SaveAllSlots_LoadScene();

    }
    /// <summary>
    /// if Question OverrideSlotIfExists for mode one only slot is NO
    /// </summary>
    public void NotOverrideSlot()
    {
        Debug.Log("Not overrride slot becase useManySlots is fase and answer is not lload game");
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
        questionScreen.GetComponent<QuestionSceenController>().OpenModal("Lose current orohgres", "Adv", Yes, No);
        //Switch Screen to question Screen
       // system.SwitchScreen(questionScreen);
    }
    public void QuestionLoseGameProgressIfExitGameFromPause( )
    {
        Yes = new UnityEvent();
        No = new UnityEvent();
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        Yes.AddListener(() => YesLostGameProgressionFromPause());
        No.AddListener(() => NoLostGameProgressionContinueFromPause());
        //Set parameters in QuestionScreen
        questionScreen.GetComponent<QuestionSceenController>().OpenModal("Lose current orohgres", "Adv", Yes, No);
        //Switch Screen to question Screen
        //system.SwitchScreen(questionScreen);
    }
    public void YesLostGameProgressionFromPause()
    {
        system.ResetListPrevScreens();
        pauseController.AllowEnterPause = false;
        GameController.Instance.currentSlot = null;
        GameController.Instance.currentSlotResume = null;
        mainMenuController.SetMainMenuWithSlots();
        pauseController.isPausedGame = false;
        pauseController.AllowEnterPause = false;
        SceneManager.LoadScene("Menu");
       // system.SwitchScreen(mainMenuController.GetComponent<UiScreen>(),true,true);
    }
    public void YesLostGameProgressionExitGame()
    {
        Application.Quit();
    }
    public void NoLostGameProgressionContinueFromPause()
    {
        system.SwitchScreen(GamePlayScreen);
    }
    #endregion
}