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
    [SerializeField] public InfoSlotResume Default;
    public GameObject SlotPrefab;
    public GameObject parentOflist;
    [HideInInspector] public InfoSlotResume previouSlotResume;
    private MenuController menuController;
    public UiSystem system;
    public UiScreen quetionScreen, GamePlayScreen;
    private UnityEvent Yes, No, Cancel;
    private EventSystem eventSystem;

    public MenuController MenuController;

    // Use this for initialization
    void Start()
    {
        Yes = new UnityEvent();
        No = new UnityEvent();
        Cancel = new UnityEvent();
        if (list == null)
            list = new List<InfoSlotResume>();


        passat = true;
    }


    public List<InfoSlotResume> list;


    // Update is called once per frame
    void Update()
    {
    }

    bool passat;
    List<InfoSlotResume> lost = new List<InfoSlotResume>();

    /// <summary>
    /// 
    /// </summary>
    public void GenerateSlots()
    {
        GameController.LoadForce();

        list = SaveData.objcts.Slots;
        list = list.Where(m => m.dataInfoSlot.typeSaveSlot == TypeOfSavedGameSlot.Manual_Save_Slot).ToList();
        foreach (Transform child in parentOflist.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        foreach (InfoSlotResume item in list)
        {
            GameObject ObjSlot = Instantiate(SlotPrefab,
                new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z),
                transform.localRotation);
            ObjSlot.GetComponent<RectTransform>().sizeDelta = new Vector2(1300, 100);
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

      //  GameController.Instance.CallTakeScreenShotOnDelay(1f,slotController.GetComponent<SlotController>().isSlotsEnabled);
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
        GameController.Save();
        SaveData.SaveSlotData(soltSlot.FileSlot, GameController.Instance.currentSlot,
            true);
        GameController.Instance.pauseController.isPausedGame = false;
        system.CallSwitchScreen(GamePlayScreen,
            delegate { GamePlayScreen.GetComponent<GamePlayController>().ShowImageSavedGame(); });
    }
}