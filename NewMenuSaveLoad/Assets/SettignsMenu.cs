using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SettignsMenu : MonoBehaviour
{
    public float TimeToTakeScreenShoot;
    public bool IsSaveingSystemEnabled;
    public bool IsSaveingInterval;

    public float SaveIntervalSeconds=2f;
    /// <summary>
    /// Says if is Screen DificultyLevelSelection is Enabled (true) of Desactive (false) 
    /// </summary>
    public bool isDificultyLevelSelectionScreenEnabled;

    /// <summary>
    /// Says if is Screen Level Selection is Enabled (true) of Desactive (false) 
    /// </summary>
    public bool isLevelSelectonScreenEnabled;
    
    public bool IsLoaderSceneWithPligun;

    public bool isLoginRegisterEnabled;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
