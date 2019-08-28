using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private UiSystem UiSystem;

    [SerializeField] private UiScreen UIScreenAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAudio()
    {
        Debug.Log("ssssssssssssmm");
        UiSystem.CallSwitchScreen(UIScreenAudio,null);
    }
}
