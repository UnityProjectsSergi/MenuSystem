using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenController: MonoBehaviour
{
   
    // Start is called before the first frame update

    
    public void FloaderScene()
    {
  
        bl_SceneLoaderUtils.GetLoaderSergi.LoadLevel("Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
