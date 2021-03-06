﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectActorData
{
   
    public string name;
    public string __prefabPath;
    public Vector3 position;
    public Quaternion rotationQuaterion;
    public Vector3 scale;
    public bool isActive;
    public LayerMask LayerMask;
    public string tag;
    public bool isStatic;
}