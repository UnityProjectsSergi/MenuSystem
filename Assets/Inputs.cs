using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public  class Inputs : MonoBehaviour
{
    private static Inputs _instance;
    [SerializeField]
    [HideInInspector]
    public InputAction BackBtnM;
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
        DontDestroyOnLoad(this.gameObject);
        _inputsControls=new Controls();
       
      // _inputsControls.UI.MoveSelection.started += ctx => MoveUISelection(ctx);
    }

    private Controls _inputsControls;
    public Vector2 MoveUi;

    
    
//
//    public bool GetUiBackButton()
//    {
//        return _inputsControls.UI.Back.triggered;
//    }
//    public bool GetUiConfrmButton()
//    {
//        return _inputsControls.UI.Confirm.triggered;
//    }

//    public Vector2 GetmoveSelection()
//    {
//        if(_inputsControls.UI.MoveSelection.triggered)
//        return _inputsControls.UI.MoveSelection.ReadValue<Vector2>();
//        else
//        {
//            return Vector2.zero;
//        }
//    }

   

  

       


    
 

    // Update is called once per frame
    void Update()
    {
        
//Debug.Log(GetmoveSelection()+"sss");
        //  Conf();
    }

    private void OnDisable()
    {
       // _inputsControls.Disable();
    }

    private void OnEnable()
    {
       // _inputsControls.Enable();
    }
}
