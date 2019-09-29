using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public enum TypeSoundBus {Unity,Wwise,Fmod }

public  class SoundSliderSlot : MonoBehaviour
{
    public Action<float> SaveVal;
    
    public TypeSoundBus typeSoundBus;
    public  Slider Slider;
    public string nameBus;
    public RTPCWwise RtpcWwise;
    public SoundBusFMOD BusFmod;
    public Text text;
    // Start is called before the first frame update
    public void Awake()
    {
        switch (typeSoundBus)
        {
            case TypeSoundBus.Wwise:
                RtpcWwise=new RTPCWwise(nameBus);
             
                break;
            case TypeSoundBus.Fmod:
                BusFmod=new SoundBusFMOD(nameBus);
                break;
            
        }
    }
    public void SetValueSlider(float value)
    {
        switch (typeSoundBus)
        {    
            case TypeSoundBus.Wwise:
                RtpcWwise.SetValueBus(value);
                break;
            case TypeSoundBus.Fmod:
                BusFmod.SetBusVolume(value);
                break;
           
        }
        Slider.value = value;
        text.text = Slider.value.ToString("0%");
        SaveVal.Invoke(value);
    }

    public float GetValueSlider()
    {
        return Slider.value;
    }

}
