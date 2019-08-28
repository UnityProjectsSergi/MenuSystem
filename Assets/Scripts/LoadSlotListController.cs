using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
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
    public UI.UI_System system;
    public UI.UI_Screen quetionScreen;
    private UnityEvent Yes, No, Cancel;
    private EventSystem eventSystem;

    // Use this for initialization
    void Start()
    {
        menuController = system.GetComponent<MenuController>();
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
        list = SaveData.objcts.Slots;
        foreach (InfoSlotResume item in list)
        {

            GameObject ObjSlot = Instantiate(SlotPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            ObjSlot.GetComponentInChildren<Text>().text = ObjSlot.name;
            ObjSlot.transform.SetParent(parentOflist.transform, false);
            SoltUI solt = ObjSlot.GetComponent<SoltUI>();
            if (solt != null)
            {
                solt.btnDel.onClick.RemoveAllListeners();
                solt.btnLoad.onClick.RemoveAllListeners();
                solt.btnLoad.onClick.AddListener(() => LoadSlot(solt.slot));
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
        Debug.Log(GameController.Instance.currentSlotResume);
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
            menuController.LoadSceneFromSlot();
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
        quetionScreen.GetComponent<QuestionSceenController>().OpenModal("Ovveride the slot current", "ddd", Yes, No, Cancel);
        system.SwitchScreen(quetionScreen,false);
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
        system.SwitchScreen(quetionScreen,false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="gameObject"></param>
    public void DeleteSlot(InfoSlotResume slot, GameObject gameObject)
    {

        Debug.Log("deleteslot");
        // ToDo Delete File of slot
        SaveData.objcts.Slots.Remove(slot);
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

        Debug.Log("deleteslot");
        //Todo Delete File of Slot
        SaveData.objcts.Slots.Remove(slot);
        GameController.Save();
        GenerateSlots();
        system.GoToPreviousScreen();
    }
    /// <summary>
    /// 
    /// </summary>
    public void LoadYesOverrideSlot(InfoSlotResume slot)
    {
        GameController.Instance.currentSlotResume = slot;
        //TODO Load file of new slot lo load on CurrentSlot
        menuController.LoadSceneFromSlot();
        Debug.Log("Load yes override current slot,Yes ");

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
            if (system.CurrentScreen.Equals(GetComponent<UI.UI_Screen>()))
            {
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
