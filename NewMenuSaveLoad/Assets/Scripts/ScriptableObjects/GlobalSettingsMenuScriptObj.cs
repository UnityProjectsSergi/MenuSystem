using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{


    [CreateAssetMenu(menuName = "GlobalSettingMenu", fileName = "GlobalSettingsMenuSystem")]
    public class GlobalSettingsMenuScriptObj : ScriptableObject
    {
        public GlobalSaveSystemSettingsScriptObj saveSystemSettings;
        public GlobalScreenSettings screenSettings;
        public GlobalLoginRegisterSettings loginRegisterSettings;
    }


   


    
}