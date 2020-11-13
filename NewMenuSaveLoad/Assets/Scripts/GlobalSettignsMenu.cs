using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum SaveSystemFormat{ JSON,Xml,Binnary}
public enum SaveSystemSourceData{ Remote,Local}
public class GlobalSettignsMenu : MonoBehaviour
{
   
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private Type DificyultiesEnum;

    // Update is called once per frame
    void Update()
    {
        
    }
}
