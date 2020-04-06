using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public  class Inputs : MonoBehaviour
{
    private static Inputs _instance;
    [SerializeField]
    [HideInInspector]
    public InputAction PauseGamePlayAction,BackAction,ExtPaseAction;

    public bool Cancel;
    public bool Pause,ExitPause;
    public PlayerInput playerInput;
    public static Inputs Instance 
    { 
        get { return _instance; } 
    } 
   
    private void Awake() 
    { 
        
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
            
            BackAction = playerInput.actions["Cancel"];
            PauseGamePlayAction = playerInput.actions["Pause"];
            ExtPaseAction = playerInput.actions["ExitPause"];
        }

        
    }
    
    public void SwitchActionMap(string map)
    {
      //  playerInput.currentActionMap.Disable();
        // TODO see if when change from to pause to main can change the module inputs
        playerInput.SwitchCurrentActionMap(map);
  //      playerInput.currentActionMap.Enable();
    }


    public Vector2 MoveUi;

   

   

  

       


    
 

    // Update is called once per frame
    void Update()
    {
      
        Cancel = BackAction.triggered;
        ExitPause = ExtPaseAction.triggered;
        Pause = PauseGamePlayAction.triggered;
            Debug.Log(playerInput.currentActionMap.name+"Actua swith action map");
        //  Debug.Log(InputPauseGame());
        //  Debug.Log(InputEnter());
    }
    
        
//Debug.Log(GetmoveSelection()+"sss");
        //  Conf();
    

    private void OnDisable()
    {
       //_inputsControls.Disable();
    }

    private void OnEnable()
    {
        //_inputsControls.Enable();
    }
}
