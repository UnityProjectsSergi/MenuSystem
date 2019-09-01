﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel : MonoBehaviour
{
    public bool initLevel;
    public float timer, init;
    // Use this for initialization
    void Start()
    {
        if (!initLevel)
        {
            StartCoroutine(ExecuteAfterTime(1f));

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        GameController.Instance.TakeScreenShot();
        initLevel = true;

    }
}
