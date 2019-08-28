using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Utils;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class SoltUI : MonoBehaviour,ISelectHandler {
    public Text text;
    public Image Screenshot;
    public InfoSlotResume slot;
    public Button btnDel;
    public Button btnLoad;
    public Text textTypeSlot;
    public Sprite defaultS;
   
  
    // Use this for initialization
    void Start () {
       
    }
	public void Init(InfoSlotResume _slot)
    {
        slot = _slot;
        if (slot.isEmpty)
            text.text = slot.Title;
        else
            text.text = Utils.MakeString(new string[] { slot.Title, " ", slot._dateTimeCreation.ToLongDateString(), " , ", slot._dateTimeCreation.ToLongTimeString() });

        textTypeSlot.text = slot.typeSaveSlot.ToString();

        if (!slot.isEmpty)
        {
            Sprite img= IMG2Sprite.LoadNewSprite(slot.ScreenShot);
            if (img)
                Screenshot.sprite = img;
            else
                Screenshot.sprite = defaultS;
        }
        else
        {
            Screenshot.sprite = defaultS;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("sss");
    }
}
