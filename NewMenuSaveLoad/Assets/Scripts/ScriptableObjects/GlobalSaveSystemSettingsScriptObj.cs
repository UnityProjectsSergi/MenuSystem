using ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GlobalSaveSystemSettingsScriptObj",fileName = "GlobalSaveSystemSettingsScriptObj")]
    public class GlobalSaveSystemSettingsScriptObj : ScriptableObject
    {
        public float TimeToTakeScreenShoot;
        public bool IsSaveingSystemEnabled;
        public bool IsSaveingInterval;
        public SaveSystemSourceData saveSourceData;
        public float saveIntervalSeconds=2f;
      
    

        public GlobalSaveSystemLocalSettingsScriptObj SaveLocalSystem;
        public GlobalSaveSystemSettingsRemoteScriptObj gsssr;

      
    }
    
   
}