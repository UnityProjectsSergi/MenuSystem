using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    
    public loaderScene loadscene;
    public UiSystem UiSystem;
    public UiScreen Options;
    public UiScreen loderSfen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLoadGame()
    {
        UiSystem.CallSwitchScreen(loderSfen,delegate {     loadscene.FloaderScene(); },true);
    
    }

    public void OpenSettings()
    {
        UiSystem.CallSwitchScreen(Options,null,false);
    }
}
