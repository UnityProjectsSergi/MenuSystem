using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GlobalLoginRegisterSettings", fileName = "GlobalLoginRegisterSettings")]
    public class GlobalLoginRegisterSettings : ScriptableObject
    {
        public bool isUserLoginRegisterActive;
        public bool AutoLoginOnRegister;

    }
}