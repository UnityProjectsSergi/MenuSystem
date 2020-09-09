using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum SaveSystemFormat{ JSON,Xml,Binnary}
public enum SaveSystemSourceData{ Remote,Local}
public class GlobalSettignsMenu : MonoBehaviour
{
    public GlobalSettings gb;
    
    [Header("Save system options")]
    public float TimeToTakeScreenShoot;
    public bool IsSaveingSystemEnabled;
    public bool IsSaveingInterval;
    public SaveSystemSourceData saveSourceData;
    public SaveSystemFormat typeSaveFormat;
    public float SaveIntervalSeconds=2f;
    [HideInInspector]
    public string currentExtFile;
    public string fileGlobalSlotsSaveData = "data", fileListUsers="listUsers";
    [HideInInspector]
    public string xmlExt=".xml",jsonExt=".json";

    [Header("Login Register Settings")] public bool isUserLoginRegisterActive;
   public bool AutoLoginOnRegister;
    
    [Header("Screens settings")]
    /// <summary>
    /// Says if is Screen DificultyLevelSelection is Enabled (true) of Desactive (false) 
    /// </summary>
    public bool isDificultyLevelSelectionScreenEnabled;

    /// <summary>
    /// Says if is Screen Level Selection is Enabled (true) of Desactive (false) 
    /// </summary>
    public bool isLevelSelectonScreenEnabled;
    
    public bool IsLoaderSceneWithPligun;
    
    private Dictionary<int, string> dificulties;
    public List<string> listsOfDificulties;
    public string BinExt {
        get { return ".bin"; }
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private Type DificyultiesEnum;

    // Update is called once per frame
    void Update()
    {
        
    }
}
