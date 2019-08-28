using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.SaveSystem1.DataClasses
{ 
    [System.Serializable]
   public class GraphicsSettingsData
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
        /// <summary>
        /// Texture Quality 
        /// </summary>
        public TextureQuality textureQuality = TextureQuality.Full_res;
        /// <summary>
        /// AntiAliasing
        /// </summary>
        public AntiAliasing antiAliasing = AntiAliasing.Disabled;
       /// <summary>
       /// VSyncCount
       /// </summary>
        public VSyncCount vSyncCount = VSyncCount.Dont_Sync;
        public FullScreenMode fullScreenMode = FullScreenMode.ExclusiveFullScreen;


    }
}
