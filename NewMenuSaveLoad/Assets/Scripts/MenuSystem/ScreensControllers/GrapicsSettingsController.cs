using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.SaveSystem1.DataClasses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrapicsSettingsController : MonoBehaviour
{
    public Toggle TogglefullScreen;
    public TMP_Dropdown DropdownResolution, DropdownQuality;
    public Dropdown dropdownResolutions,dropdownQuality;
    private GraphicsSettingsData _loadedGraphicsParameters = null;
    /// <summary>
    /// Override Audio Parameters local
    /// </summary>
    private readonly GraphicsSettingsData _overrideGraphicsParameters;
    /// <summary>
    /// Default Audio Parameters
    /// </summary>
    public GraphicsSettingsData DefaultGraphicsParameters;
    public GraphicsSettingsData Parameters
    {
        get
        {
            if (_loadedGraphicsParameters != null)
            {
                return _loadedGraphicsParameters;
            }
            else
            {
                return _overrideGraphicsParameters ?? DefaultGraphicsParameters;
            }
        }
        set { }
    }

    public Dropdown Resolutions;
    public bool fullScreen;

    public bool isloadedoption;
    // default params options
    
    // list of resolutions filtered
    private List<Resolution> filterdResoltions;
    // list of qualities
    private List<string> listQualities;
    // list of full resolutions
    private List<Resolution> listResolutions;
    // int num index for default resolution
    private int num=0;
// TODO make the UI and save data from these data 
    private List<TextureQuality> listTextQualities;
    private List<AntiAliasing> listAntialiasing;
    private List<AnisotropicFiltering> listAnisotropicFilterings;
    private int pixelLightCount;
    private ShadowProjection shadowProjection;
    private int shadowCascades;
    private float shadowDistance;
    private ShadowResolution shadowResolution;
    private ShadowmaskMode shadowmaskMode;
    private float shadowNearPlaneOffset;
    private float lodBias;
    private int masterTextureLimit;
    private List<ShadowQuality> listShadowQuality; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.hasLoadedGameData)
        {
            //get Instances from Unity or FMOD or WWISE call SoundSliderSlot.IniBus
            if (GameController.Instance.fileExists)
                _loadedGraphicsParameters = SaveData.objcts.Parameters.Graphics;
        }

    
          filterdResoltions = new List<Resolution>();
  //      GrapicsGameSettings Settings = GrapicsGameSettings.Instance;
        // set defaut options of instance with default options of component script
       
        // set dropdowns
        #region Set Dropdown Qualty;

            dropdownQuality.ClearOptions();
        dropdownResolutions.ClearOptions();
        DropdownQuality.ClearOptions();
        DropdownResolution.ClearOptions();
        dropdownQuality.AddOptions(QualitySettings.names.ToList());
        DropdownQuality.AddOptions(QualitySettings.names.ToList());
        dropdownQuality.value = (int)SaveData.objcts.Parameters.Graphics.currentQualityLevel;
        DropdownQuality.value=(int)SaveData.objcts.Parameters.Graphics.currentQualityLevel;
        #endregion
        #region Set Dropdown Reslutions
        List<string> resos = new List<string>();
        int lw = -1;
        int lh = -1;
        int index = 0;
        int currentResIndex=-1;
        foreach(var resolution in Screen.resolutions)
        {
            if (lw != resolution.width || lh != resolution.height)
            {
                // add the filter resolution to the list
                filterdResoltions.Add(resolution);
                // create a neatly formated string to add to the dropdown 
                string fmt = string.Format(" {0} x {1} ", resolution.width, resolution.height);
                resos.Add(fmt);
               
                lw = resolution.width;
                lh = resolution.height;
                //figured out if this is the users's current resolution
                if (lw == SaveData.objcts.Parameters.Graphics.width && lh == SaveData.objcts.Parameters.Graphics.height)
                    currentResIndex = index;
                index++;
            }
            
        }
        dropdownResolutions.ClearOptions();
        DropdownResolution.ClearOptions();
        
        dropdownResolutions.AddOptions(resos);
        DropdownResolution.AddOptions(resos);
        dropdownResolutions.value = currentResIndex;
        DropdownResolution.value = currentResIndex;
        Screen.SetResolution( SaveData.objcts.Parameters.Graphics.width, SaveData.objcts.Parameters.Graphics.height, SaveData.objcts.Parameters.Graphics.isFullScreen);
        #endregion
        // SetDefaults
//        SetDefaults();
       
    }

    private void SetDefaults()
    {
        Parameters = DefaultGraphicsParameters;
        
        SaveGraphicsData();
    }
    public void SetParametersOnSaveData()
    {
        SaveData.objcts.Parameters.Graphics = Parameters;
    }
    
    private void SaveGraphicsData()
    {
        SetParametersOnSaveData();
        GameController.Save();
    }

    public void OnValueChangeQuality(int num)
    {
        QualitySettings.SetQualityLevel(num);
        Parameters.currentQualityLevel = (GrapicsSettings)num;
        SaveGraphicsData();
    }

    public void OnValueChangeResolution(int num)
    {
        Resolution res = filterdResoltions[DropdownResolution.value];
        Screen.SetResolution(res.width,res.height,fullScreen);
        Parameters.height = res.height;
        Parameters.width = res.width;
        SaveGraphicsData();
    }
    public void setFullScreen(bool newValue)
    {
        Parameters.isFullScreen = newValue;
        Screen.fullScreen = newValue;
        fullScreen = newValue;
        SaveGraphicsData();
    }
}
