using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SaveSystem1.DataClasses;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SaveGameController : MonoBehaviour
{
    /// <summary>
    /// Save UI Prefab Slot
    /// </summary>
    public GameObject SaveUISlotPrefab;
    /// <summary>
    /// Content GameObject of list of slots
    /// </summary>
    public GameObject parentOflist;
    /// <summary>
    /// Save Previous slot resume for not override when save data
    /// </summary>
    [HideInInspector] public InfoSlotResume previouSlotResume;
    /// <summary>
    /// Reference to UI System Script 
    /// </summary>
    public UiSystem system;
    /// <summary>
    /// Reference to question Screen and GamePlayScreen
    /// </summary>
    public UiScreen quetionScreen, GamePlayScreen;
    /// <summary>
    /// list Of Slots
    /// </summary>
    public List<InfoSlotResume> listSlots;
    [Tooltip("On save Manual if True goto GamePlay and if false return to SaveGame")]
    /// <summary>
    /// bool is is true return to gameplay or is false return to menu savegame
    /// </summary>
    public bool returnToMenuOrGameplay;
    /// <summary>
    /// Unity Events Yes no And Cancel
    /// </summary>
    private UnityEvent Yes, No, Cancel;
    /// <summary>
    /// Reference to evenySystem
    /// </summary>
    private EventSystem eventSystem;
    /// <summary>
    /// Reference to Menu Controller Script
    /// </summary>
    private MenuController menuController;

    // Use this for initialization
    void Start()
    {
        // initialize Unity Events and list of Slots
        Yes = new UnityEvent();
        No = new UnityEvent();
        Cancel = new UnityEvent();
        if (listSlots == null)
            listSlots = new List<InfoSlotResume>();


    }
    /// <summary>
    /// Generate slots list methos 
    /// </summary>
    public void GenerateSlots()
    {
        // force load Data
        GameController.LoadForce();
        // get list slots
        listSlots = SaveData.objcts.Slots;
        // filter list slots for Manual save slots
        listSlots = listSlots.Where(m => m.dataInfoSlot.typeSaveSlot == TypeOfSavedGameSlot.Manual_Save_Slot).ToList();
        // loop the children Transform of parentOfList to Delete children of content gameobject to reset the view of slots
        foreach (Transform child in parentOflist.transform)
            GameObject.Destroy(child.gameObject);
        // loop the list slots
        foreach (InfoSlotResume item in listSlots)
        {
            /// instanciate objSlot 
            GameObject ObjSlot = Instantiate(SaveUISlotPrefab,
                new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z),
                transform.localRotation);
            // Set text in ui Text
            ObjSlot.GetComponent<RectTransform>().offsetMax=new Vector2(20,50);
            ObjSlot.GetComponent<RectTransform>().offsetMin=new Vector2(200,50);
            ObjSlot.GetComponent<RectTransform>().sizeDelta=new Vector2(800,75);
            ObjSlot.GetComponentInChildren<TextMeshProUGUI>().text = ObjSlot.name;
            // set objSlot child of parentOfList Content
            ObjSlot.transform.SetParent(parentOflist.transform, true);
            // get GetComponent SlotUI in objSlot
            SoltUI solt = ObjSlot.GetComponent<SoltUI>();
            if (solt != null)
            {
                // Remove all Llisteners
                solt.btnLoadSave.onClick.RemoveAllListeners();
                // add listener 
                solt.btnLoadSave.onClick.AddListener(() => OverrideSaveSlot(solt.slot));
                // Slot initiate
                solt.Init(item);
            }
        }
    }
    
    GameObject NewSlot;
    private InfoSlotResume slot;
    /// <summary>
    /// Generate New Slot in list
    /// </summary>
    public void GenerateNewSlot()
    {
        // create new slot
        slot = new InfoSlotResume(DateTime.Now);
        // create folder
        slot.CrateFolder();
        // Copy from current slot
        slot.CopySlotResume(GameController.Instance.currentSlotResume);
        // set slot typeSave to manual
        slot.dataInfoSlot.typeSaveSlot = TypeOfSavedGameSlot.Manual_Save_Slot;
        slot.dataInfoSlot.datetimeSaved=DateTime.Now;
        // add slot to listSlots
        SaveData.objcts.Slots.Add(slot);
        // save slotdata
        SaveData.SaveSlotData(slot.FileSlot, slot.slotGame, true);
        // Save list slot data
        GameController.Save();
        // if returnToaGamepley is true
        if (returnToMenuOrGameplay)
        {
            // set is paused game flag to false
            GameController.Instance.pauseController.isPausedGame = false;
            // 
           
            system.CallSwitchScreen(GamePlayScreen,
                delegate { GamePlayScreen.GetComponent<GamePlayController>().ShowImageSavedGame(); });
        }
        // return to menu SaveGame
        else
        {
            GenerateSlots();    
        }
    }
    /// <summary>
    /// Call Event override save slot
    /// </summary>
    /// <param name="soltSlot">Slot of </param>
    private void OverrideSaveSlot(InfoSlotResume soltSlot)
    {
        AskForOverrideSaveSlot(soltSlot);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="soltSlot"></param>
    private void AskForOverrideSaveSlot(InfoSlotResume soltSlot)
    {
        Yes.RemoveAllListeners();
        No.RemoveAllListeners();

        Yes.AddListener(() => YesOverrideSaveSlot(soltSlot));
        No.AddListener(() => NoOverrideSaveSlot());
        quetionScreen.GetComponent<QuestionSceenController>()
            .OpenModal("Save Override the slot current", "You  Sure Save Override?", Yes, No);
        system.CallSwitchScreen(quetionScreen);
    }

    private void NoOverrideSaveSlot()
    {
        GameController.Instance.currentSlotResume = previouSlotResume;
        Debug.Log("Load new slot No");
        system.GoToPreviousScreen();
    }

    private void YesOverrideSaveSlot(InfoSlotResume slot)
    {
        
        GameController.Instance.currentSlotResume.dataInfoSlot.datetimeSaved = DateTime.Now;
        GameController.Save();
        SaveData.SaveSlotData(slot.FileSlot, GameController.Instance.currentSlot,
            true);
        GameController.Instance.pauseController.isPausedGame = false;
        if (returnToMenuOrGameplay)
        {
            system.CallSwitchScreen(GamePlayScreen,
                delegate { GamePlayScreen.GetComponent<GamePlayController>().ShowImageSavedGame(); });
        }
        else
        {
            system.GoToPreviousScreen();
        }
    }
}