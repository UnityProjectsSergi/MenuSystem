using System;
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
    public string __prefabPath;
    public Vector3 position;
    public Quaternion rotationQuaterion;
    public Vector3 scale;
    public bool isActive;
    public LayerMask LayerMask;
    public string tag;
    public bool isStatic;
    #if UNITY_EDITOR
    public StaticEditorFlags staticFlag;
    #endif
}