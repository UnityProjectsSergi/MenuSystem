using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControlerSingleton : MonoBehaviour
{

    
    // Start is called before the first frame update
 
    public static MenuControlerSingleton instance;
 
    void Awake(){
        if (instance == null)  
            instance = this;
        else 
            DestroyImmediate(this.gameObject);
    }
 
    void Start () {DontDestroyOnLoad (this.gameObject);}
    
    // Update is called once per frame
}
