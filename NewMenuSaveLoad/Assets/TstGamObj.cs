using System.Collections;
using System.Collections.Generic;
using Assets.SaveSystem1.DataClasses;
using UnityEngine;

public class TstGamObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           SaveController.Instance.LoadSaveSlotWeb();
        }
    }
}
