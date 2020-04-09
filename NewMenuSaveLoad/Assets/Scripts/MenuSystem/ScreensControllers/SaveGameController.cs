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
            // 
          
            ObjSlot.GetComponentInChildren<Text>().text = ObjSlot.name;

            ObjSlot.transform.SetParent(parentOflist.transform, true);
            SoltUI solt = ObjSlot.GetComponent<SoltUI>();
            if (solt != null)
            {
                //  solt.btnDel.onClick.RemoveAllListeners();
                solt.btnLoadSave.onClick.RemoveAllListeners();
                solt.btnLoadSave.onClick.AddListener(() => OverrideSaveSlot(solt.slot));
                // solt.btnDel.onClick.AddListener(() => AskForSaveSlot(solt.slot, ObjSlot));

                solt.Init(item);
            }
        }
    }

    GameObject NewSlot;
    private InfoSlotResume slot;

    public void GenerateNewSlot()
    {
        slot = new InfoSlotResume(DateTime.Now);

        slot.CrateFolder();
       
        if (GameController.Instance.hasCurrentSlot)
        {
            slot.CopySlotResume(GameController.Instance.currentSlotResume);
            slot.dataInfoSlot.typeSaveSlot = TypeOfSavedGameSlot.Manual_Save_Slot;
           
        }
        else
        {
            GameController.Instance.currentSlotResume = slot;
            GameController.Instance.currentSlot = slot.slotGame;
        }

        GameController.Instance.CallTakeScreenShotOnDelay(1f,true);
        SaveData.objcts.Slots.Add(slot);
        SaveData.SaveSlotData(slot.FileSlot, slot.slotGame, true);

        
        GameController.Save();
        GenerateSlots();
    }

    public void SaveNewSlot(InfoSlotResume soltSlot)
    {
        Debug.Log("save slot");

        SaveData.objcts.Slots.Add(soltSlot);
        GameController.Save();

        // GenerateNewSlot();

        //
    }

    private void OverrideSaveSlot(InfoSlotResume soltSlot)
    {
        AskForOverrideSaveSlot(soltSlot);
    }

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

    private void YesOverrideSaveSlot(InfoSlotResume soltSlot)
    {
        GameController.Instance.currentSlotResume.dataInfoSlot.datetimeSaved = DateTime.Now;
        SaveData.objcts.previousSlotLoaded = soltSlot;
        GameController.Save();
        SaveData.SaveSlotData(soltSlot.FileSlot, GameController.Instance.currentSlot,
            true);
        GameController.Instance.pauseController.isPausedGame = false;
        system.CallSwitchScreen(GamePlayScreen,
            delegate { GamePlayScreen.GetComponent<GamePlayController>().ShowImageSavedGame(); });
    }
    
}