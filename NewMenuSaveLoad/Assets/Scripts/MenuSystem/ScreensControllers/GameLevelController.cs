using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.SaveSystem1.DataClasses;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Inputs.Instance.SaveTrigg)
       {
            Debug.Log("SAVE");
         GameController.SaveGame();
       }
        if (Input.GetKeyDown(KeyCode.D))
       {
            SaveSlotObj(); 
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load");
            GameController.LoadForce();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            //SaveData.LoadGameSlotData();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Create");
            CreateGameObject(_prefab, new Vector3(2, 5, 0), Quaternion.identity);
        }
    }

    public GameObject _prefab ;

    public static void SaveSlotObj()
    {
        SaveData.SaveSlotData<GameSlot>(GameController.Instance.currentSlotResume.FileSlot, GameController.Instance.currentSlot, true);
    }
    /// <summary>
    /// Create GameObject in scene
    /// </summary>
    /// <param name="prefab">Prefab </param>
    /// <param name="position">Position of gameobject</param>
    /// <param name="rotation">Rotatio of gameobject</param>
    /// <returns></returns>
    public static ObjToSave CreateGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab != null)
        {
            GameObject go = Instantiate(prefab, position, rotation);
            SceneManager.MoveGameObjectToScene(go,
                SceneManager.GetSceneByName(GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay));
            ObjToSave obj = go.GetComponent<ObjToSave>();
            if (obj == null)
                go.AddComponent<ObjToSave>();
            return obj;
        }
        else
        {
            Debug.Log("Prefab is null");
            return null;
        }
    }

    /// <summary>
    /// Create Game Object that has been saven on file
    /// </summary>
    /// <param name="data">Object Data from file</param>
    /// <param name="position">Position from file</param>
    /// <param name="rotation">Rrotation from file</param>
    /// <returns></returns>
    public static ObjToSave CreateObjSaved(GameObjectActorData data)
    {
//        Debug.Log(data.__prefabPath+"\\"+data.name.Remove(data.name.Length-7)+" vvvv"+ Resources.Load<GameObject>(data.__prefabPath+"/"+data.name.Remove(data.name.Length-7)));
        ObjToSave obj = CreateGameObject(Resources.Load<GameObject>(data.prefabPath+Path.DirectorySeparatorChar+data.name.Remove(data.name.Length-7)), data.position, data.rotation);
        obj.gameObjSave.data = data;
        return obj;
    }

}
