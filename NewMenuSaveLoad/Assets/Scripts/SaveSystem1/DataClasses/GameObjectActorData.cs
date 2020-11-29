﻿using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GameObjectActorData
{
    [Newtonsoft.Json.JsonConstructor]
    public GameObjectActorData()
    {
        
    }
    
    public string name;
    public string prefabPath;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public bool isActive;
    public int layerMask;
    
    public string tag;
    public bool isStatic;
    public TestSO TestSO;
    public ObjData Objdata;
    #if UNITY_EDITOR
    public StaticEditorFlags staticFlag;
    #endif
}