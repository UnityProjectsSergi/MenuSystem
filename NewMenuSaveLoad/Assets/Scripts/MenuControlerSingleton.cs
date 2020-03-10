using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControlerSingleton : MonoBehaviour
{

    private MenuControlerSingleton _instance;
    // Start is called before the first frame update
 
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
