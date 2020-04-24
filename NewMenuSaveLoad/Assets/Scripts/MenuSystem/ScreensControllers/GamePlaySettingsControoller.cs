using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class GamePlaySettingsControoller : MonoBehaviour
{
    // TODO GameDificulty
    
    // Start is called before the first frame update
    void Start()
    {
        // game dificulty 
        
        //TextureQuality
          //AntiAliasing
            //VSyncCount
            //  Skin
           /// Sha
           TierSettings d =new TierSettings();
       //    GraphicsTier.Tier1.
           GraphicsTier m = GraphicsTier.Tier2;
           Graphics.activeTier = m;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
