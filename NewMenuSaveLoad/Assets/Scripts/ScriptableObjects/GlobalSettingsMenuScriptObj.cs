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


    [CreateAssetMenu(menuName = "GlobalScreenSettings", fileName = "GlobalScreenSettings")]
    public class GlobalScreenSettings : ScriptableObject
    {
        public bool isDificultyLevelSelectionScreenEnabled;

        /// <summary>
        /// Says if is Screen Level Selection is Enabled (true) of Desactive (false) 
        /// </summary>
        public bool isLevelSelectonScreenEnabled;

        public bool IsLoaderSceneWithPligun;

        private Dictionary<int, string> dificulties;
        public List<string> listsOfDificulties;
    }


    [CreateAssetMenu(menuName = "GlobalLoginRegisterSettings", fileName = "GlobalLoginRegisterSettings")]
    public class GlobalLoginRegisterSettings : ScriptableObject
    {
        public bool isUserLoginRegisterActive;
        public bool AutoLoginOnRegister;

    }
}