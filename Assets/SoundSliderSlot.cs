using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Slider = UnityEngine.UIElements.Slider;

public class SoundSliderSlot : MonoBehaviour
{
    
    public Slider Slider;
    public string nameBus;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    public virtual void InitBus()
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
