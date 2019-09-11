using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UIElements.Slider;

public class SoundSliderSlotFMOD: SoundSliderSlot
{
    
    // puf FMOD Instance

    
    // Start is called before the first frame update
    void Start()
    {
        #if FMOD
        Debug.Log("sssssssssssssssss");
        if(Utils.NamespaceExists("FMOD"))
        {
          
            Debug.Log("FmodExists");
        }
        else
        {
            Debug.LogError("You Define FMOD Symbol but need import FMOD Pakage");
        }
        #endif
    }

    public override void InitBus()
    {
        // set 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetDefaultSlider(float num)
    {
        
        Slider.value = num;
    }
}
