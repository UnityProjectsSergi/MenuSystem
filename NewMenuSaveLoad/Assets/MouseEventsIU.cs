using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseEventsIU : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundFX.PlaySoundFX("Click",gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundFX.PlaySoundFX("Click",gameObject);
        
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SoundFX.PlaySoundFX("Click",gameObject);
       Debug.Log("Exit");
    }
    public static bool BlockedByUI;
    private EventTrigger eventTrigger;
 
 
}
