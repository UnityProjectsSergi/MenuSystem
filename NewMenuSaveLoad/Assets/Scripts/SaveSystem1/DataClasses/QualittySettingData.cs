using UnityEngine;

namespace SaveSystem1.DataClasses
{
    [System.Serializable]
    public class QualittySettingData : MonoBehaviour
    {
        
        /// <summary>
        /// Quality Settings.
        /// </summary>
        public GrapicsSettings currentQualityLevel = GrapicsSettings.Medium;
        /// <summary>
        /// Screen resoltion width.
        /// </summary>
        public int width = 1024;
        /// <summary>
        /// Screen resolution height.
        /// </summary>
        public int height = 768;
        /// <summary>
        /// True is game is in full screen.
        /// </summary>
        public bool isFullScreen;
    }
}