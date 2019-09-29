using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.SaveSystem1.DataClasses;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    private AudioSettingsData _loadedAudioParameters = null;
    /// <summary>
    /// Override Audio Parameters local
    /// </summary>
    private readonly AudioSettingsData _overrideAudioParameters;
    /// <summary>
    /// Default Audio Parameters
    /// </summary>
    public AudioSettingsData DefaultAudioParameters;
    public AudioSettingsData Parameters
    {
        get
        {
            if (_loadedAudioParameters != null)
            {
                return _loadedAudioParameters;
            }
            else
            {
                return _overrideAudioParameters ?? DefaultAudioParameters;
            }
        }
        set { }
    }

    public SoundSliderSlot SlotMaster, SlotMusic, SlotSFX, SlotVoices;
   
    /// <summary>
    /// 
    // Start is called before the first frame update 
    void Start()
    {
        if (GameController.hasLoadedGameData)
        {
            //get Instances from Unity or FMOD or WWISE call SoundSliderSlot.IniBus
            if (GameController.Instance.fileExists)
                _loadedAudioParameters = SaveData.objcts.Parameters.Sound;
        }
        SerActionsOnSlots();
        SetDefaults();
    }

    public void SetParametersOnSaveData()
    {
        SaveData.objcts.Parameters.Sound = Parameters;
    }

    public void SetDefaults()
    {
        Debug.Log((SlotMusic+""+ Parameters.musicValue));
        if(SlotMusic!=null)
         SlotMusic.SetValueSlider(Parameters.musicValue);
        if(SlotMaster!=null)
         SlotMaster.SetValueSlider(Parameters.masterValue);
        if(SlotVoices!=null)
          SlotVoices.SetValueSlider(Parameters.voicesValue);
        if(SlotSFX!=null)
          SlotSFX.SetValueSlider(Parameters.soundFXValue);
        
    }

    public void SerActionsOnSlots()
    {
        if(SlotMaster!=null)
            SlotMaster.SaveVal += SetMasterVolume;
        if(SlotMusic!=null)
            SlotMusic.SaveVal += SetMusicVolume;
        if(SlotVoices!=null)
            SlotVoices.SaveVal += SetVoicesVolume;
        if(SlotSFX!=null)
            SlotSFX.SaveVal += SetSfxVolume;
    }

    public void SetMasterVolume(float value)
    {
        Parameters.masterValue = value;
        SaveAudioData();
    }
    public void SetMusicVolume(float value)
    {
        Parameters.musicValue = value;
        SaveAudioData();
    }
    public void SetVoicesVolume(float value)
    {
        Parameters.voicesValue = value;
        SaveAudioData();
    }
    public void SetSfxVolume(float value)
    {
        Parameters.soundFXValue = value;
        SaveAudioData();
    }
    private void SaveAudioData()
    {
        SetParametersOnSaveData();
        GameController.Save();
    }
}
