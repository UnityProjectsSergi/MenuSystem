using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private UiSystem uiSystem;

    [SerializeField] private UiScreen UIScreenAudio=null,UIScreenGamePlay=null,UiScreenGrapics=null;
    // Start is called before the first frame update
    #region Variables Public
   
    public Button SoundButton;
    public Button GamplayButton;
    public Button LlanguageButton;
    public Button CreditsButton;
    public Button HudConfigButton;
    public Button CameraButton;
    public Button AssessibilityButton;

    public Button VideoButton;

    #endregion
    #region Variables Private
    
    private SettngsButtons settingsButtons;
    #endregion
    #region Unity Methods
    // Use this for initialization
    void Start () {
        settingsButtons = GetComponent<SettngsButtons>();
       
        SoundButton.gameObject.SetActive(settingsButtons.isSoundSettingsEnabled);
        GamplayButton.gameObject.SetActive(settingsButtons.isGamePlaySettingsEnabled);
//          CameraButton.gameObject.SetActive(settingsButtons.isCameraSettingsEnabled);
//        HudConfigButton.gameObject.SetActive(settingsButtons.isHudConfigSettingsEnabled);
//        AssessibilityButton.gameObject.SetActive(settingsButtons.isAccessibilitySettingsEnabled);
//        CameraButton.gameObject.SetActive(settingsButtons.isAccessibilitySettingsEnabled);
//        CreditsButton.gameObject.SetActive(settingsButtons.isCreditsScreenEnabled);
//        LlanguageButton.gameObject.SetActive(settingsButtons.isLlanguageSettingsEnabled);
          //  BackButton.gameObject.SetActive(true);
            
    }
	
    // Update is called once per frame
    void Update () {
		
    }
    #endregion

    public void OpenAudioSettings()
    {
        uiSystem.CallSwitchScreen(UIScreenAudio,null);
    }

    public void OpenGamePlaySettings()
    {
        uiSystem.CallSwitchScreen(UIScreenGamePlay);
    }

    public void OpenGrapicsSettings()
    {
        uiSystem.CallSwitchScreen(UiScreenGrapics);
    }
  
}
