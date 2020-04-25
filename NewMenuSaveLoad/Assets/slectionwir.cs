using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slectionwir : MonoBehaviour,ISelectHandler,IDeselectHandler
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("  btn Selected "+eventData.selectedObject.name);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        
    }
}
