using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;


public enum TypeSoundBus {Unity,Wwise,Fmod }

public  class SoundSliderSlot : MonoBehaviour
{
    public Action<float> SaveVal;
    [HideInInspector]
    public TypeSoundBus typeSoundBus;
    public  Slider Slider;
    public string nameBus;
    public RTPCWwise RtpcWwise;
    public SoundBusFMOD BusFmod;
    public AudioMixer audioMixer;
   

    public TMP_Text textPro;
    // Start is called before the first frame update
    public void Awake()
    {
        try
        {
            switch (typeSoundBus)
            {
                case TypeSoundBus.Wwise:
                    RtpcWwise = new RTPCWwise(nameBus);

                    break;
                case TypeSoundBus.Fmod:
                    BusFmod = new SoundBusFMOD(nameBus);
                    break;
              
            }
        }
        catch (ExceptionSound e)
        {
            Debug.LogError("Error On Create Obj of Sound "+e.Message);
        }
    }
    
    public void OnChangeValueSlider(float value)
    {
        try
        {
            switch (typeSoundBus)
            {
                case TypeSoundBus.Wwise:
                    RtpcWwise.SetValueBus(value);
                    break;
                case TypeSoundBus.Fmod:
                    BusFmod.SetBusVolume(value);
                    break;
                case TypeSoundBus.Unity:
                    if(nameBus.Equals("MasterVolume"))
                    audioMixer.SetFloat(nameBus.Remove(6), value);
                    else
                    {
                        audioMixer.SetFloat(nameBus, value);
                    }
                    break;

            }
            Slider.value = value;
          
                textPro.text= Slider.value.ToString("0%");
            
            SaveVal.Invoke(value);
        }
        catch (ExceptionSound e)
        {
            Debug.LogError("error on setting the Value Volume on"+ e.Message);
        }
    }

    public float GetValueSlider()
    {
        return Slider.value;
    }

    public void Update()
    {
        Debug.Log(nameBus.Remove(6));
    }
}
