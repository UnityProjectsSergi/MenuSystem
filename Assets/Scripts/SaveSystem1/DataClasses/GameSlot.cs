using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
namespace Assets.SaveSystem1.DataClasses
{
    [System.Serializable]
    public class GameSlot
    {
       
        /// <summary>
        ///  List of GameObjectActorDataIn Slot
        /// </summary>
        /// // 
        [SerializeField]
        public int NumObj { get { return ObjectsToSaveInSlot.Count; } set { } }
        public List<GameObjectActorData> ObjectsToSaveInSlot = new List<GameObjectActorData>();
        public static explicit operator bool(GameSlot v)
        {
            return (v != null);
        }
[Range(0,1)]
        public float health=1;
    }
}
