﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenController: MonoBehaviour
{
   
    // Start is called before the first frame update

    
    public void FloaderScene()
    {
        bl_SceneLoaderUtils.GetLoaderSergi.LoadLevel(GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay);
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}
