using UnityEngine;
using  UnityEngine.EventSystems;
public class KeyboardController : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject currentSelectedGameobject;

    /// <summary>
    /// Use this for initialization 
    /// </summary>
    private void Awake()
    {

    }
    /// <summary>
    /// Use this for initialization 
    /// </summary>
    public void Start()
    {
        //Set current Selectes Object
        currentSelectedGameobject = eventSystem.currentSelectedGameObject;
    }
    
    /// <summary>
    ///  Update is called once per frame 
    /// </summary>
    void Update()
    {
        //if currentSeleteddObj of EventSystem is diffferen of CurreentSelctedObjlocal
        if (eventSystem.currentSelectedGameObject != currentSelectedGameobject)
        {
            /// currentSelctedObj of event system is null
            if (eventSystem.currentSelectedGameObject == null)
                // Set Selected GameObj the local curent Selected GameObj
                eventSystem.SetSelectedGameObject(currentSelectedGameobject);
            else
                //Set the current Select GameObj with EventSystem currentSelectedGameObj
                currentSelectedGameobject = eventSystem.currentSelectedGameObject;
        }
    }

    /// <summary>
    /// Set Next selcted GameObj
    /// </summary>
    public void SetNextSelectedGameobject(GameObject NextGameObject)
    {
        //if NextGameObj is not null
        if (NextGameObject != null)
        {
            // current SelctedGameObj is NextGameObj
            currentSelectedGameobject = NextGameObject;
            // set on eventSysyem the currentSelectedGameObj with local currentSelected gameObj
            eventSystem.SetSelectedGameObject(currentSelectedGameobject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    //public void OnGUI()
    //{
    //    Event e = Event.current;
        
    //    if (e.type==EventType.KeyDown && e.keyCode==KeyCode.E && e.isKey)
    //    {
    //        if (currentSelectedGameobject.GetComponent<Button>() != null)
    //            currentSelectedGameobject.GetComponent<Button>().onClick.Invoke();
    //    }
    //} 
}
