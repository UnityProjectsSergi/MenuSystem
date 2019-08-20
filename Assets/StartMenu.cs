using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public loaderScene loadscene;
    public UiSystem UiSystem;
    public UiScreen loderSfen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(UiSystem.SwitchScreen(loderSfen,delegate {     loadscene.FloaderScene(); }));
    
    }
}
