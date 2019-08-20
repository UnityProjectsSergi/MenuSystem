using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loaderScene : MonoBehaviour
{
    private UiScreen uiscreen;
    // Start is called before the first frame update
    void Start()
    {
        uiscreen = GetComponent<UiScreen>();
    }

    public void FloaderScene()
    {
     
        bl_SceneLoaderUtils.GetLoader.LoadLevel("Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
