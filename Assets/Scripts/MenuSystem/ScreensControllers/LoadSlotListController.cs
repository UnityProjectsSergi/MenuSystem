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

    public GameObject SlotPrefab;
    public GameObject parentOflist;
    [HideInInspector]
    public InfoSlotResume previouSlotResume;
    private MenuController menuController;
    public UiSystem system;
    public UiScreen quetionScreen;
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
        list.Clear();
        list = SaveData.objcts.Slots;
        
        foreach (InfoSlotResume item in list)
        {

            GameObject ObjSlot = Instantiate(SlotPrefab, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), transform.localRotation);
            ObjSlot.GetComponent<RectTransform>().sizeDelta=new Vector2(1300,100);
            ObjSlot.GetComponentInChildren<Text>().text = ObjSlot.name;
            ObjSlot.transform.SetParent(parentOflist.transform, true);
            SoltUI solt = ObjSlot.GetComponent<SoltUI>();
            if (solt != null)
            {
                solt.btnDel.onClick.RemoveAllListeners();
                solt.btnLoadSave.onClick.RemoveAllListeners();
                solt.btnLoadSave.onClick.AddListener(() => LoadSlot(solt.slot));
                solt.btnDel.onClick.AddListener(() => AskForDeleteSlot(solt.slot, ObjSlot));
                solt.Init(item);
            }

        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="slot"></param>
    public void LoadSlot(InfoSlotResume slot)
    {
        Debug.Log("Load Slot");
       
        //if has currentSlot so I'm in pause Menu and select load game 
        if ((bool)GameController.Instance.currentSlotResume)
        {
            previouSlotResume = GameController.Instance.currentSlotResume;
            AskForOverridecurrentSlot(slot);
            
        }
        else
        {
            Debug.Log("No has Curect Slot in Instace");
            GameController.Instance.currentSlotResume = slot;
            SaveData.objcts.previousSlotLoaded = slot;
            GameController.Save();
            Debug.Log("Enter Load from slot");
            MenuController.LoadSceneFromSlot();
        }
    }
    public void AskForOverridecurrentSlot(InfoSlotResume slot)
    {
        No.RemoveAllListeners();
        Yes.RemoveAllListeners();
        Cancel.RemoveAllListeners();
        Yes.AddListener(() => LoadYesOverrideSlot(slot));
        No.AddListener(() => LoadSlotNoOverrideSlot());
        Cancel.AddListener(() => LoadSlotCanelOverrideSlot());
        quetionScreen.GetComponent<QuestionSceenController>().OpenModal("Ovveride the slot current", "You Sure Override?", Yes, No, Cancel);
       system.CallSwitchScreen(quetionScreen);
    }
    /// <summary>
    /// 
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
    /// 
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="gameObject"></param>
    public void DeleteSlot(InfoSlotResume slot, GameObject gameObject)
    {

        Directory.Delete(Application.persistentDataPath + "/" +slot.FolderOfSlot, true);
        SaveData.objcts.Slots.Remove(slot);
        if (SaveData.objcts.Slots.Count == 0)
            SaveData.objcts.previousSlotLoaded = null;
        GameController.Save();
        Destroy(gameObject);
        GenerateSlots();
        system.GoToPreviousScreen();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="gameObject"></param>
    public void DeleteSlot(InfoSlotResume slot)
    {
        Directory.Delete(Application.persistentDataPath + "/" +slot.FolderOfSlot, true);
        SaveData.objcts.Slots.Remove(slot);
        if (SaveData.objcts.Slots.Count == 0)
            SaveData.objcts.previousSlotLoaded = null;
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
        if (e.isKey && e.type == EventType.KeyDown)
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
        }

    }
}
