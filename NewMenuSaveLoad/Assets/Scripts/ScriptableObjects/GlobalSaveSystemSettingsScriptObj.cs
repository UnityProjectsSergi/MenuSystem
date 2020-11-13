using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "SaveSystemSettingMenu",fileName = "SaveSystemSettingsMenuSystem")]
    public class GlobalSaveSystemSettingsScriptObj : ScriptableObject
    {
        public float TimeToTakeScreenShoot;
        public bool IsSaveingSystemEnabled;
        public bool IsSaveingInterval;
        public SaveSystemSourceData saveSourceData;
        public SaveSystemFormat typeSaveFormat;
        public float saveIntervalSeconds=2f;
        [HideInInspector]
        public string currentExtFile;
        public string fileGlobalSlotsSaveData = "data", fileListUsers="listUsers";
        [HideInInspector]
        public string xmlExt=".xml",jsonExt=".json", binExt=".data";
    }
}