using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.SaveSystem1.DataClasses;
using UnityEngine;

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
   

    public SoundSliderSlot SoundSliderSlotMaster;
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
    }

    public void SetParametersOnSaveData()
    {
        SaveData.objcts.Parameters.Sound = Parameters;
    }

    public void SetDefaults()
    {
        SoundSliderSlotMaster.SetDefaultSlider(Parameters.masterValue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
