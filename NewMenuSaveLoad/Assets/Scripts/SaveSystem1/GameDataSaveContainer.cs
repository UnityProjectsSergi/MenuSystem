using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SaveSystem1.DataClasses;
public class GameSlotObjectsContainer
{
   public GameSlot Slot = new GameSlot();
    public static explicit operator bool(GameSlotObjectsContainer v)
    {
        return (v != null);
    }
}
[System.Serializable]
public class GameDataSaveContainer {
    // fer una classe Data difrenprefab 
    /// <summary>
    ///  List of GameObjectActorData
    /// </summary>
    /// // 
    // [SerializeField]
    //public int NumObj { get { return ObjectsToSave.Count; } set { } }
    //public List<GameObjectActorData> ObjectsToSave = new List<GameObjectActorData>();

    public bool IsCurrentGameLoaded;
    /// <summary>
    /// Index of Slots 
    /// </summary>
    public List<InfoSlotResume> Slots = new List<InfoSlotResume>();
    /// <summary>
    /// Object GameParametres
    /// </summary>
    public GameParameters Parameters = new GameParameters();
    // Use this for initialization
    public InfoSlotResume previousSlotLoaded=null;
 
    
}
