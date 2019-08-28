using Assets.SaveSystem1.DataClasses;
using Assets.Scripts.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// GameParameters Class for save the Parameters of menu.
[System.Serializable]
public class GameParameters
{
    
    public GraphicsSettingsData Graphics = new GraphicsSettingsData();
    public GamePlaySettingsData GamePlay = new GamePlaySettingsData();
    public AudioSettingsData Sound = new AudioSettingsData();

}



