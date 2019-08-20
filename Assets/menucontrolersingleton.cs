using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menucontrolersingleton : MonoBehaviour
{

    private menucontrolersingleton _instance;
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
