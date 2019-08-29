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
            _dateTimeCreation = dateCreation;
           
        }
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

                    SaveData.SaveToFile<GameSlot>(FileSlot, new GameSlot(), true);
                }
                folderDone = true;
            }
        }
        /// <summary>
        /// datetimeSaved Slot
        /// </summary>
        public  DateTime _dateTimeCreation;
        //public string dateTimeSaved;
        /// <summary>
        /// datetimeSaved Slot
        /// </summary>
        public DateTime _datetimeSaved = DateTime.Now;
        public string FolderOfSlot="";
        /// <summary>
        /// Screen Shot of chekpoint
        /// </summary>
        public string ScreenShot=null;
    
        /// <summary>
        /// Title of Slot
        /// </summary>
        public string Title = "ssss";

        /// <summary>
        ///  List of GameObjectActorDataIn Slot
        /// </summary>
        /// // 
        //[SerializeField]
        //public int NumObj { get { return ObjectsToSaveInSlot.Count; } set { } }
        //public List<GameObjectActorData> ObjectsToSaveInSlot = new List<GameObjectActorData>();
        /// <summary>
        /// Level of dificulty of game
        /// </summary>
        public GameDifficulty gameDifficulty=GameDifficulty.Easy;
        /// <summary>
        /// typeSaveSlotof slot
        /// </summary>
        public TypeOfSavedGameSlot typeSaveSlot=TypeOfSavedGameSlot.Checkpoint;

        public static explicit operator bool(InfoSlotResume v)
        {
            return (v != null);
        }
        /// <summary>
        /// currentLevelPlay
        /// </summary>
        public string currentLevelPlay="";
        internal bool isEmpty=false;
        public string FileSlot;
        
    }
}
