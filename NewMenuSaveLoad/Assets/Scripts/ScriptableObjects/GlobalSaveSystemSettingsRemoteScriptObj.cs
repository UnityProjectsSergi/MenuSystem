using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "GlobalSaveSystemSettingsRemoteScriptObj",fileName = "GlobalSaveSystemSettingsRemoteScriptObj")]
    public class GlobalSaveSystemSettingsRemoteScriptObj : ScriptableObject
    {
        public string server;
        public string port;
    }
}