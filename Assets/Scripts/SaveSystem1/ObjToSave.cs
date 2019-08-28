using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjToSave : MonoBehaviour
{

    public GameObjectActor gameObjSave;
    public string pathOfPrefab;
    public bool isDirty; 
    // Use this for initialization
    void Awake()
    {
       //fa elmateix tots 2 aquet ho fa al iniciar el objecte un cop i l'altre h fa cada vegada q dono a s i despres buia la llista 
         gameObjSave = new GameObjectActor(gameObject,pathOfPrefab);
      
      //  SaveData.objcts.ObjectsToSave.Add(gameObjSave.data);
        //isDirty = true;
    }

    // Update is called once per frame
    void Update()
    {
   
    }
     void OnEnable()
    {
        gameObjSave.OnEnable();
    }
    void OnDisable()
    {
        gameObjSave.OnDisable();   
    }

}