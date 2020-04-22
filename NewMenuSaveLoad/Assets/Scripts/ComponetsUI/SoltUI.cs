using System;
using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Utils;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public enum TypeSlotUI
{
    SaveSlot,LoadSlot
}

public class SoltUI : MonoBehaviour,ISelectHandler,IDeselectHandler {
    /// <summary>
    /// Name UI Text
    /// </summary>
    public Text Name;
    /// <summary>
    /// Screenshot UI Image
    /// </summary>
    public Image Screenshot;
    /// <summary>
    /// Data from infoSlotResume on UI
    /// </summary>
    public InfoSlotResume slot;

    public TypeSlotUI typeSlot;
    public Button btnDel;
    public Button btnLoadSave;
    public Text textTypeSlot;
    public Sprite defaultS;
    
    public EventTrigger onClickLoadEvent;
    public EventTrigger onClickDelEvent;
    [HideInInspector]
   public EventTrigger.Entry entryDel = new EventTrigger.Entry( );
   [HideInInspector]
    public EventTrigger.Entry entryLoadEvent= new EventTrigger.Entry( );
    [HideInInspector]
    public EventTrigger.Entry entryLoadConfirm= new EventTrigger.Entry( );

    public bool isGenEvent;
    public void Awake()
    {
        if (typeSlot == TypeSlotUI.LoadSlot)
        {
            onClickLoadEvent = onClickLoadEvent.gameObject.GetComponent<EventTrigger>();
            entryLoadEvent.eventID = EventTriggerType.PointerClick;
            onClickDelEvent = onClickDelEvent.gameObject.GetComponent<EventTrigger>();
            entryDel.eventID = EventTriggerType.PointerClick;
            
        }
        else
        {
            onClickLoadEvent = GetComponent<EventTrigger>();
            entryLoadEvent.eventID = EventTriggerType.PointerClick;
        }
        entryLoadConfirm.eventID = EventTriggerType.Submit;
    }
    // Use this for initialization
    public void Init(InfoSlotResume _slot)
    {
        slot = _slot;
        Name.text = Utils.MakeString(new string[] { slot.dataInfoSlot.Title, " ", slot.dataInfoSlot.dateTimeCreation.ToLongDateString(), " , ", slot.dataInfoSlot.dateTimeCreation.ToLongTimeString() });
        textTypeSlot.text = slot.dataInfoSlot.typeSaveSlot.ToString();
        try
        {
            Sprite img = IMG2Sprite.LoadNewSprite(slot.dataInfoSlot.ScreenShot);
            if (img)
                Screenshot.sprite = img;
        }
        catch (NullReferenceException e)
        {
            Debug.Log("ScreenShot is null "+e.Message+" Set Default Image ");
        }
        catch (Exception e)
        {
            Debug.Log("eRrror on load image"+e.Message+"Set default image");
        }
        Screenshot.sprite = defaultS;
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("sss");
    }

    public void OnDeselect(BaseEventData eventData)
    {
       Debug.Log("ssssssssssssssc");
    }
}
