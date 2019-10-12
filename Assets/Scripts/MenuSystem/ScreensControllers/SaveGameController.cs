using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SaveSystem1.DataClasses;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class SaveGameController : MonoBehaviour
{
    public GameObject SlotPrefab;
    public GameObject parentOflist;
    [HideInInspector] public InfoSlotResume previouSlotResume;
    private MenuController menuController;
    public UiSystem system;
    public UiScreen quetionScreen,GamePlayScreen;
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

    }

    List<InfoSlotResume> list;

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void GenerateSlots()
    {
        Debug.Log("GenerateSlotList");
        list.Clear();
        list = SaveData.objcts.Slots.Where(c=>c.typeSaveSlot==TypeOfSavedGameSlot.Manual_Save_Slot).ToList();
        Debug.Log(SaveData.objcts.Slots.Count);

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
          //      solt.btnDel.onClick.RemoveAllListeners();
                solt.btnLoadSave.onClick.RemoveAllListeners();
                solt.btnLoadSave.onClick.AddListener(() => SaveSlot(solt.slot));
            //    solt.btnDel.onClick.AddListener(() => AskForSaveSlot(solt.slot, ObjSlot));
                Debug.Log(item.folderDone + " " + item.ScreenShot);
                solt.Init(item);
            }

        }

    }

    private void SaveSlot(InfoSlotResume soltSlot)
    {
        AskForOverrideSaveSlot(soltSlot);
    }

    private void AskForOverrideSaveSlot(InfoSlotResume soltSlot)
    {
        Yes.RemoveAllListeners();
        No.RemoveAllListeners();
   
        Yes.AddListener(()=>YesOverrideSaveSlot(soltSlot));
        No.AddListener(()=>NoOverrideSaveSlot());
        quetionScreen.GetComponent<QuestionSceenController>().OpenModal("Save Override the slot current", "You  Sure Save Override?", Yes, No);
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
        soltSlot.typeSaveSlot = TypeOfSavedGameSlot.Manual_Save_Slot;
        SaveData.SaveSlot(soltSlot.FileSlot, GameController.Instance.currentSlot,
            true);
        system.CallSwitchScreen(GamePlayScreen);
    }
}