using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadSlotListController : MonoBehaviour
{
    /// <summary>
    /// Reference to MainMenu
    /// </summary>
    public UiScreen MainMenu;
    /// <summary>
    /// Load UI Prefab Slot
    /// </summary>
    public GameObject loadSlotUIPrefab;
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
    /// Reference to question Screen 
    /// </summary>
    public UiScreen quetionScreen;
    List<InfoSlotResume> slotList;
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
    public MenuController MenuController;

    private UiScreen ownScreen;
    // Use this for initialization
    void Start()
    {
        // initialize Unity Events and list of Slots  
        Yes = new UnityEvent();
        No = new UnityEvent();
        Cancel = new UnityEvent();
        if (slotList == null)
            slotList = new List<InfoSlotResume>();
        ownScreen = GetComponent<UiScreen>();
    }
  
    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Generate slots list methos 
    /// </summary>
    public void GenerateSlots()
    {
        // foce load data
        GameController.LoadForce();
        // slotList clear items
        slotList.Clear();
        // get list from data
        slotList = SaveData.objcts.Slots;
        // loop the children Transform of parentOfList to Delete children of content gameobject to reset the view of slots
        foreach (Transform child in parentOflist.transform) 
            GameObject.Destroy(child.gameObject);
        

        int i = 0;
        foreach (InfoSlotResume item in slotList)
        {
            
            Debug.Log(item.FileSlot+"num");
            // Instanciate loadSlotUIpreafb
            GameObject ObjSlot = Instantiate(loadSlotUIPrefab, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), transform.localRotation);
           // set parent of parentOfList
            ObjSlot.GetComponent<RectTransform>().offsetMax=new Vector2(20,50);
           ObjSlot.GetComponent<RectTransform>().offsetMin=new Vector2(200,200);
            ObjSlot.GetComponent<RectTransform>().sizeDelta=new Vector2(800,75);
            ObjSlot.transform.SetParent(parentOflist.transform, true);
            // set select the objSlot
            ownScreen.UiElements.Add(ObjSlot);
            ObjSlot.name += i;
            // get Script SlotUI from objSlot
            SoltUI soltUi = ObjSlot.GetComponent<SoltUI>();
            // if slot is sett
            if (soltUi != null)
            {
                // remove and load butons the Delete Listener
                
              //  soltUi.btnDel.onClick.RemoveAllListeners();
               // soltUi.btnLoadSave.onClick.RemoveAllListeners();
                // Add new listener to LoadBtn and Del btn
               
                //soltUi.btnLoadSave.onClick.AddListener();
              //  soltUi.btnDel.onClick.AddListener(() => AskForDeleteSlot(soltUi.slot, ObjSlot));
              soltUi.entryLoadEvent.callback.AddListener((data) => LoadSlot(soltUi.slot));
              soltUi.entryLoadConfirm.callback.AddListener((data) => LoadSlot(soltUi.slot));
              soltUi.onClickLoadEvent.triggers.Add(soltUi.entryLoadEvent);
              soltUi.onClickLoadEvent.triggers.Add(soltUi.entryLoadConfirm);
           
              soltUi.entryDel.callback.AddListener((data) =>AskForDeleteSlot(soltUi.slot,ObjSlot));
              soltUi.onClickDelEvent.triggers.Add(soltUi.entryDel);
              // Init UI of slottUI
                
                soltUi.Init(item);
            }
            if (i == 0)
            {
                ownScreen.defaultSelected = ObjSlot;
                ObjSlot.GetComponent<Selectable>().Select();
            }
            ownScreen.UiElements.Add(ObjSlot.gameObject);
            i++;
        }

    }
    /// <summary>
    /// On Click of load slot button fires
    /// </summary>
    /// <param name="slot"></param>
    public void LoadSlot(InfoSlotResume slot)
    {
        //if has currentSlot so I'm in pause Menu and select load game 
        if ((bool)GameController.Instance.currentSlotResume)
        {
            // save the curretslotresume at previousSlotResume
            previouSlotResume = GameController.Instance.currentSlotResume;
            // ask if ovrrive cuurent slot
            AskForOverridecurrentSlot(slot);
            
        }
        else
        {
            // set slot in currentSlot instace
            GameController.Instance.currentSlotResume = slot;
            // set slot in previu slot loaded in save data
            SaveData.objcts.previousSlotLoaded = slot;
            // Save data
            GameController.Save();
            Debug.Log("Enter Load from slot");
            // load from slot scene
            MenuController.LoadSceneFromSlot();
        }
    }
    /// <summary>
    /// Resolves the open modal for ask is override Current slot
    /// </summary>
    /// <param name="slot"></param>
    public void AskForOverridecurrentSlot(InfoSlotResume slot)
    {
        // remoe the llisteners of No,Yes,Cancel buttons
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        Cancel.RemoveAllListeners();
        // add listeners of yes,no,cancel
        Yes.AddListener(() => LoadYesOverrideSlot(slot));
        No.AddListener(() => LoadSlotNoOverrideSlot());
        Cancel.AddListener(() => LoadSlotCanelOverrideSlot());
        // set modal screen data with open modal
        quetionScreen.GetComponent<QuestionSceenController>().OpenModal("Ovveride the slot current", "You Sure Override?", Yes, No, Cancel);
        // SwitchScreen to questionScreen
       system.CallSwitchScreen(quetionScreen);
    }
    /// <summary>
    /// Resolves the open modal screen to ask for sure delete slot 
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="gameObject"></param>
    public void AskForDeleteSlot(InfoSlotResume slot, GameObject gameObject)
    {
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        Yes.AddListener(() => DeleteSlot(slot, gameObject));
        No.AddListener(() => system.GoToPreviousScreen());
        quetionScreen.GetComponent<QuestionSceenController>().OpenModal("Delete slot", "ddd", Yes, No);
        system.CallSwitchScreen(quetionScreen);
    }
    /// <summary>
    /// Executes de Yes action llistenen for the ask delete slot modal
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="gameObject"></param>
    public void DeleteSlot(InfoSlotResume slot, GameObject gameObject)
    {
        // deletedirectory of slot
        Directory.Delete(Application.persistentDataPath + "/" +slot.FolderOfSlot, true);
        // remove slot fron data slots
        SaveData.objcts.Slots.Remove(slot);
   
           
        
         ///TODO Veure si el jugador ha eliminat l'unic slot si es joc un slot
         /// Si es unic slot
          
         if (GameController.Instance.hasCurrentSlot)
         {
             if (SaveData.objcts.Slots.Count >=1)
             {
                 Debug.Log("Encara cquenen slors");
                 if (slot.Equals(SaveData.objcts.previousSlotLoaded))
                 {
                     Debug.Log("estic elimnt slot pev load");
                 }
                 
             }
             else
             {
                 Debug.Log("Exitc eliminat utilm slot");
                 SaveData.objcts.previousSlotLoaded = null;
                 GameController.Instance.hasCurrentSlot = false;
                 GameController.Instance.currentSlotResume = null;
                 GameController.Instance.currentSlot = null;
             }
         }

         GameController.Save();
         Destroy(gameObject);
            GenerateSlots();
            // IF HAS CURRENT SLOT SO IS IN PAUSE MENU
            if(GameController.Instance.hasCurrentSlot)
                  MenuController.mainMenuController.SetPauseMenuwithSlots();
            else
                MenuController.mainMenuController.SetMainMenuWithSlots();
            system.CallSwitchScreen(MainMenu);    
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="gameObject"></param>
    public void DeleteSlot(InfoSlotResume slot)
    {
      
        Debug.Log("sssssssssssss Del");
        SaveData.objcts.Slots.Remove(slot);
        Directory.Delete(Application.persistentDataPath + "/" +slot.FolderOfSlot, true);
        if (SaveData.objcts.Slots.Count == 0)
            SaveData.objcts.previousSlotLoaded = null;
        else
        {
            Debug.Log(slot);
            if (slot == SaveData.objcts.previousSlotLoaded)
            {
                SaveData.objcts.previousSlotLoaded=SaveData.objcts.Slots[0];
            }
        }
        GameController.Save();
        GenerateSlots();
        system.GoToPreviousScreen();
    }

    public PauseController pauseController;
    /// <summary>
    /// 
    /// </summary>
    public void LoadYesOverrideSlot(InfoSlotResume slot)
    {
        Debug.Log("ssss load override slot");
        GameController.Instance.currentSlotResume = slot;
        
        pauseController.isPausedGame = false;
        pauseController.AllowEnterPause = false;
        //Todo Somehow de 
        MenuController.LoadSceneFromSlot();
    }
    /// <summary>
    /// 
    /// </summary>
    public void LoadSlotNoOverrideSlot()
    {
        GameController.Instance.currentSlotResume = previouSlotResume;
        Debug.Log("Load new slot No");
        system.GoToPreviousScreen();
    }
    /// <summary>
    /// 
    /// </summary>
    public void LoadSlotCanelOverrideSlot()
    {
        GenerateSlots();
        system.GoToPreviousScreen();
    }
    public void OnGUI()
    {

        Event e = Event.current;
        /*if (e.isKey && e.type == EventType.KeyDown)
        {
            if (system.CurrentScreen.Equals(GetComponent<UiScreen>()))
            {
                //if(Inputs.Instance.in)
                if (e.keyCode == KeyCode.Delete)
                {
                    DeleteSlot(EventSystem.current.GetComponent<SoltUI>().slot);
                }
                if (e.keyCode == KeyCode.E)
                {
                    LoadSlot(EventSystem.current.GetComponent<SoltUI>().slot);
                }
            }
        }*/

    }
}
