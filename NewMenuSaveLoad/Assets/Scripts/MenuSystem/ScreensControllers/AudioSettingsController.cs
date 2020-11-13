﻿using System.Collections;
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
    }

    public TypeSoundBus typeSoundBus;
    public SoundSliderSlot SlotMaster, SlotMusic, SlotSFX, SlotVoices;

    public void InitDataAudioSettings()
    {
        SetActionsOnSlots();
        if (GameController.hasLoadedGameData)
        {
            if (GameController.Instance.dataExists)
                _loadedAudioParameters = SaveData.objcts.Parameters.Sound;
            LoadSlidersValues();
        }
        else
        {
            SetDefaults();
        }
    }

    private void LoadSlidersValues()
    {
        SlotMaster.OnChangeValueSlider(Parameters.masterValue);
        SlotMusic.OnChangeValueSlider(Parameters.musicValue);
        SlotVoices.OnChangeValueSlider(Parameters.voicesValue);
        SlotSFX.OnChangeValueSlider(Parameters.soundFXValue);
        SlotMaster.typeSoundBus = typeSoundBus;
        SlotMusic.typeSoundBus = typeSoundBus;
        SlotVoices.typeSoundBus = typeSoundBus;
        SlotSFX.typeSoundBus = typeSoundBus;
    }

    void Start()
    {
        if (!GameController.Instance.globalSettignsMenuSC.loginRegisterSettings.isUserLoginRegisterActive)
        {
            InitDataAudioSettings();
        }
    }

    public void SetSoundParametersOnSaveData()
    {
        SaveData.objcts.Parameters.Sound = Parameters;
    }

    public void SetDefaults()
    {
        if(SlotMusic!=null)
         SlotMusic.OnChangeValueSlider(DefaultAudioParameters.musicValue);
        if(SlotMaster!=null)
         SlotMaster.OnChangeValueSlider(DefaultAudioParameters.masterValue);
        if(SlotVoices!=null)
          SlotVoices.OnChangeValueSlider(DefaultAudioParameters.voicesValue);
        if(SlotSFX!=null)
          SlotSFX.OnChangeValueSlider(DefaultAudioParameters.soundFXValue);
        SaveAudioData();
    }

    public void SetActionsOnSlots()
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
        SetSoundParametersOnSaveData();
        GameController.SaveGame();
    }
}
