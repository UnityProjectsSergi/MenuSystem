using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using Assets.Scripts.Utils;
using UnityEngine.Serialization;

namespace Assets.SaveSystem1.DataClasses
{
    [System.Serializable]
    public class InfoSlotResume
    {
        public bool folderDone = false;
        [System.NonSerializedAttribute]
        public GameSlot slotGame;
        public string FolderOfSlot="";
        public string FileSlot;

        public DataInfoSlot dataInfoSlot;

        public InfoSlotResume()
        {
            
        }
        public InfoSlotResume(DateTime dateCreation, string Title = null, GameDifficulty difficulty = GameDifficulty.None,string screenSlot=null )
        {
            slotGame=new GameSlot();
            dataInfoSlot=new DataInfoSlot();
           dataInfoSlot.dateTimeCreation = dateCreation;
           
        }
      
        public void CrateFolder()
        {
            if (!folderDone)
            {
                if (FolderOfSlot == "") FolderOfSlot = Path.GetRandomFileName();
                if (!File.Exists(Application.persistentDataPath + "/" + FolderOfSlot))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/" + FolderOfSlot);
                    FileSlot = Utils.MakeString(new string[] { Application.persistentDataPath, "/", FolderOfSlot, "/", "Slot_" + Path.GetRandomFileName() + GameController.Instance.globalSettignsMenu.currentExtFile });
                   
                }
                folderDone = true;
            }
        }
    
        

        public static explicit operator bool(InfoSlotResume v)
        {
            return (v != null);
        }
        public void CopySlotResume(InfoSlotResume data)
        {
            this.dataInfoSlot.copyDataInfoSlot(data.dataInfoSlot);
            this . dataInfoSlot.ScreenShot = Application.persistentDataPath + "/" + FolderOfSlot + "/Screenshot.png";
            File.Copy(data.dataInfoSlot.ScreenShot,Application.persistentDataPath+"/"+FolderOfSlot+"/Screenshot.png");
        }

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

        public string game2dif;
        /// <summary>
        /// typeSaveSlotof slot
        /// </summary>
        public TypeOfSavedGameSlot typeSaveSlot=TypeOfSavedGameSlot.Checkpoint;
        /// <summary>
        /// datetimeSaved Slot
        /// </summary>
        [FormerlySerializedAs("_dateTimeCreation")] public  DateTime dateTimeCreation;
        /// <summary>
        /// datetimeSaved Slot
        /// </summary>
        [FormerlySerializedAs("_datetimeSaved")] public DateTime datetimeSaved = DateTime.Now;

        public void copyDataInfoSlot(DataInfoSlot data)
        {
            currentLevelPlay = data.currentLevelPlay;
            dateTimeCreation = data.dateTimeCreation;
            gameDifficulty = data.gameDifficulty;
            Title = data.Title;
        }
    }
}
