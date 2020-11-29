using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "GlobalSaveSystemLocalSettingsScriptObj",
        fileName = "GlobalSaveSystemLocalSettingsScriptObj")]
    public class GlobalSaveSystemLocalSettingsScriptObj : ScriptableObject
    {
        public string datapathFinal,dataPathListUsers;
        public SaveSystemFormat typeSaveFormat;
        [HideInInspector] public string currentExtFile;
        public string fileGlobalSlotsSaveData = "data", fileListUsers = "listUsers";
        [HideInInspector] public string xmlExt = ".xml", jsonExt = ".json", binExt = ".data";

        public string InitParthsData()
        {
            if (typeSaveFormat == SaveSystemFormat.JSON)
                currentExtFile = jsonExt;
            else if (typeSaveFormat == SaveSystemFormat.Xml)
                currentExtFile = xmlExt;
            else if (typeSaveFormat == SaveSystemFormat.Binnary)
                currentExtFile = binExt;
            if (!fileGlobalSlotsSaveData.Contains(currentExtFile))
            {
                fileGlobalSlotsSaveData +=
                    currentExtFile;

            }

            datapathFinal = System.IO.Path.Combine(Application.persistentDataPath,
                fileGlobalSlotsSaveData);
            return datapathFinal;
        }

        public string InitUserListDataPath()
        {
            if (!fileListUsers.Contains(currentExtFile))
            {
             fileListUsers +=
                    currentExtFile;
                    
            }
            dataPathListUsers = System.IO.Path.Combine(Application.persistentDataPath,
               fileListUsers);
            return dataPathListUsers;
        }
    }
}