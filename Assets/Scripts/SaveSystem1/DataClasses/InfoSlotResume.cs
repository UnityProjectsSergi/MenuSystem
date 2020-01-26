using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using Assets.Scripts.Utils;

namespace Assets.SaveSystem1.DataClasses
{
    [System.Serializable]
    public class InfoSlotResume
    {
        public bool folderDone = false;
        
        public InfoSlotResume(DateTime dateCreation, string Title = null, GameDifficulty difficulty = GameDifficulty.None,string screenSlot=null )
        {
            slotGame=new GameSlot();
            dataInfoSlot=new DataInfoSlot();
           dataInfoSlot. _dateTimeCreation = dateCreation;
           
        }
        [System.NonSerializedAttribute]
        public GameSlot slotGame;
        public void CrateFolder()
        {
            if (!folderDone)
            {
                if (FolderOfSlot == "") FolderOfSlot = Path.GetRandomFileName();
                if (!File.Exists(Application.persistentDataPath + "/" + FolderOfSlot))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/" + FolderOfSlot);
                    FileSlot = Utils.MakeString(new string[] { Application.persistentDataPath, "/", FolderOfSlot, "/", "Slot_" + Path.GetRandomFileName() + ".json" });
                    // FileSlot = (System.IO.Path.Combine(Application.persistentDataPath,System.IO.Path.Combine(FolderOfSlot,"Slot_" + Path.GetRandomFileName()+".json")));
                    
                    SaveData.SaveToFile<GameSlot>(FileSlot, slotGame, true);
                }
                folderDone = true;
            }
        }
      
        //public string dateTimeSaved;
    
        public string FolderOfSlot="";
      
    

        /// <summary>
        ///  List of GameObjectActorDataIn Slot
        /// </summary>
        /// // 
        //[SerializeField]
        //public int NumObj { get { return ObjectsToSaveInSlot.Count; } set { } }
        //public List<GameObjectActorData> ObjectsToSaveInSlot = new List<GameObjectActorData>();
        

        public static explicit operator bool(InfoSlotResume v)
        {
            return (v != null);
        }
        /// <summary>
        /// currentLevelPlay
        /// </summary>
  
       
        public string FileSlot;

        public DataInfoSlot dataInfoSlot;


    }
    [System.Serializable]
    public class DataInfoSlot
    {
        public string currentLevelPlay="";
        
        /// <summary>
        /// Title of Slot
        /// </summary>
        public string Title = "ssss";
        /// <summary>
        /// Screen Shot of chekpoint
        /// </summary>
        public string ScreenShot=null;
        /// <summary>
        /// Level of dificulty of game
        /// </summary>
        public GameDifficulty gameDifficulty=GameDifficulty.Easy;
        /// <summary>
        /// typeSaveSlotof slot
        /// </summary>
        public TypeOfSavedGameSlot typeSaveSlot=TypeOfSavedGameSlot.Checkpoint;
        /// <summary>
        /// datetimeSaved Slot
        /// </summary>
        public  DateTime _dateTimeCreation;
        /// <summary>
        /// datetimeSaved Slot
        /// </summary>
        public DateTime _datetimeSaved = DateTime.Now;
    }
}
