using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public  class Inputs : MonoBehaviour
{
    private InputsControls _inputsControls;

    public  bool BackPresed;
    // Start is called before the first frame update
    void Awake()
    {
        _inputsControls=new InputsControls();
        _inputsControls.Menu.Back.performed += ctx => Back(ctx);
    }

    private void Back(InputAction.CallbackContext ctx)
    {
        BackPresed = ctx.performed;

        Debug.Log("ssssddggtyrf");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        _inputsControls.Disable();
    }

    private void OnEnable()
    {
        _inputsControls.Enable();
    }
}
