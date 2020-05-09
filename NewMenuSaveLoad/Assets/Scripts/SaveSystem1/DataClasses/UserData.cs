using System.Collections.Generic;
using System.IO;
using Assets.SaveSystem1.DataClasses;
using Assets.Scripts.Utils;
using UnityEngine;


namespace SaveSystem1.DataClasses
{
    public class UserData
    {
        private int id;
        public string Firstnam, LastName;
        public string Username;
        public string password;
        public string email;
        public string FileOfGameData;
        public string FolderOfGameData;
        public GameDataSaveContainer GameDataSaveContainer;
        bool folderDone;

        public UserData(string _firstName,string _lastName,string _username,string _password,string _email)
        {
            id = 2;
            Firstnam = _firstName;
            LastName = _lastName;
            Username = _username;
            password = _password;
            email = _email;
            CrateFolder();
        }

        public void CrateFolder()
        {
            if (!folderDone)
            {
                if (FolderOfGameData == "")
                    FolderOfGameData = Path.GetRandomFileName()+Username;
                if (!File.Exists(Application.persistentDataPath + "/" + FolderOfGameData))
                {
                    if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.JSON)
                        Directory.CreateDirectory(Application.persistentDataPath + "/" + FolderOfGameData);
                    FileOfGameData = Utils.MakeString(new string[]
                    {
                        Application.persistentDataPath, "/", FolderOfGameData, "/",
                        "GameData_" + Path.GetRandomFileName() +Username+
                        GameController.Instance.globalSettignsMenu.currentExtFile
                    });
                }

                folderDone = true;
            }
        }
    }

    public class CheckUserData
    {
        public string identifier;
        public string password;

        public CheckUserData(string _password, string _username)
        {
            password = _password;
            identifier = _username;
        }
    }
}