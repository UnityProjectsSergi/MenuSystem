using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region class GameObjectActor
public class GameObjectActor
{
    #region Public Variables
    /// <summary>
    /// local GameObject of scene
    /// </summary>
    public GameObject gameObj;
    /// <summary>
    /// GameObject Data Object from file
    /// </summary>
    public GameObjectActorData data = new GameObjectActorData();
    //  public Dictionary<String,Object> data =new Dictionary<String,Object>();
    /// <summary>
    /// Local Prefab Path to Prefab of gameObj
    /// </summary>
    public string _prefabPath;

    //  public bool isSaved;
    #endregion
    
    #region Contructor Method
    /// <summary>
    /// Ccontructor of Class
    /// </summary>
    /// <param name="obj">The gameObject of the Data</param>
    /// <param name="prefabPath">Prefab for create gameoobj</param>
    public GameObjectActor(GameObject obj = null, string prefabPath = "")// string ObjStringName="")
    {
        //is obj is null Error
        if (!obj)
        {
            Debug.LogError("Need to GameOject derived from MonoBehaviour");
        }
        // if prefabPath is "" Error
        if (prefabPath == "")
            Debug.LogError("need pass a path of prefab for load gameobjects");
        // assign Parameters to local variables 
        gameObj = obj;
        _prefabPath = prefabPath;
    }
    #endregion

    #region  Methods of the class
    /// <summary>
    /// Assign funtions in events on Enabled or create GameOibject
    /// </summary>
    public void OnEnable()
    {
        SaveData.OnLoaded += LoadDataObject;
        SaveData.OnBeforeSave += StoreDataObject;
        SaveData.OnBeforeSave += ApplyData;
    }
    /// <summary>
    /// Apply data non list of GameObjectActor
    /// </summary>
    public  void ApplyData()
    {
        SaveData.AddGameObjectData(data);
    }
    /// <summary>
    /// Erase funtions in events on Disable or Destroy Game Object
    /// </summary>
    public void OnDisable()
    {
        SaveData.OnLoaded -= LoadDataObject;
        SaveData.OnBeforeSave -= StoreDataObject;
        SaveData.OnBeforeSave -= ApplyData;
    }
    /// <summary>
    /// Store data from gameObject to dataObj
    /// </summary>
    public  void StoreDataObject()
    {
        // data.position.SetPosition(gameObj.transform.position);
        data.name = gameObj.name;
       
        data.position = gameObj.transform.position;
        data.rotationQuaterion = gameObj.transform.rotation;
        data.scale = gameObj.transform.localScale;
        data.__prefabPath = _prefabPath;
        data.isActive = gameObj.activeSelf;
        data.LayerMask = gameObj.layer;
        data.tag = gameObj.tag;
        data.isStatic = gameObj.isStatic;
        
    }
    /// <summary>
    /// Loads data from dataObj to gameObject
    /// </summary>
    public  void LoadDataObject()
    {
        //gameObj.transform.position = data.position.GetPosition();
        gameObj.name = data.name;
        gameObj.transform.localScale = data.scale;
        gameObj.transform.position = data.position;
        gameObj.transform.rotation = data.rotationQuaterion;
        _prefabPath = data.__prefabPath;
        gameObj.SetActive(data.isActive);
        gameObj.layer = data.LayerMask;
        gameObj.tag = data.tag;
        gameObj.isStatic = data.isStatic;
     
    }
    #endregion

}
#endregion

