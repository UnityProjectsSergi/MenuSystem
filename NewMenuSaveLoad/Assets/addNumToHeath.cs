﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addNumToHeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.currentSlot!=null && GameController.Instance)
            if (!GameController.Instance.pauseController.isPausedGame)
                GameController.Instance.currentSlot.health += 0.000005f * Time.deltaTime;
                
        
    }
}
