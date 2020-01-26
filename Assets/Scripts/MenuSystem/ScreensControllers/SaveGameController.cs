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
    [SerializeField]
    public InfoSlotResume Default;
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
      
        
        passat = true;

    }

  

   public List<InfoSlotResume> list;
   public InfoSlotResume[] list3;
   
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
        Debug.Log("sssssssssssssss");
             
                  list.Clear();
                list = SaveData.objcts.Slots;
              lost.Clear();
              // foreach (var item in list)
              //     
              // {    
              //     Debug.Log(item.FileSlot+" "+item.dataInfoSlot.typeSaveSlot);
              //     if (item.dataInfoSlot.typeSaveSlot == TypeOfSavedGameSlot.Manual_Save_Slot)
              //     {
              //         lost.Add(item);
              //     }
              // }

              /*for(int  i=1;i<parentOflist.transform.childCount;i++)
              {
                    Destroy(parentOflist.transform.GetChild(i).gameObject);
              }*/
      
           Debug.Log(lost.Count);
            foreach (InfoSlotResume item in lost)
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
       Debug.Log("GenNewSlot");
        
        
         slot = new InfoSlotResume(DateTime.Now);
     
         slot.CrateFolder();
         slot.dataInfoSlot.typeSaveSlot =TypeOfSavedGameSlot.Manual_Save_Slot;
         slot.slotGame = GameController.Instance.currentSlot;
         SaveData.SaveSlotData(slot.FileSlot,slot.slotGame,true);
         slot.dataInfoSlot.Title = GameController.Instance.currentSlotResume.dataInfoSlot.Title;
         
         NewSlot=Instantiate(SlotPrefab,   new Vector3(parentOflist.transform.localPosition.x, parentOflist.transform.localPosition.y, parentOflist.transform.localPosition.z),
             parentOflist.transform.localRotation);
        NewSlot.GetComponent<RectTransform>().sizeDelta = new Vector2(1300, 75);
        NewSlot.GetComponentInChildren<Text>().text = "NewSlot";
        NewSlot.transform.SetParent(parentOflist.transform, true);
        SoltUI soltUI = NewSlot.GetComponent<SoltUI>();
     
      

        soltUI.Init(slot);
        if (soltUI != null)
        {
            //      solt.btnDel.onClick.RemoveAllListeners();
            soltUI.btnLoadSave.onClick.RemoveAllListeners();
            soltUI.btnLoadSave.onClick.AddListener(() => OverrideSaveSlot(slot));
            //    solt.btnDel.onClick.AddListener(() => AskForSaveSlot(solt.slot, ObjSlot));
           
        }
        GameController.Save();
        GenerateSlots();
    }

    public void SaveNewSlot(InfoSlotResume soltSlot)
    {
   
        
        Debug.Log("save slot");
       
        SaveData.objcts.Slots.Add(soltSlot);
        GameController.Save();
 
        GenerateNewSlot();
        
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
        
        SaveData.SaveSlotData(soltSlot.FileSlot, GameController.Instance.currentSlot,
            true);
        system.CallSwitchScreen(GamePlayScreen);
    }
}