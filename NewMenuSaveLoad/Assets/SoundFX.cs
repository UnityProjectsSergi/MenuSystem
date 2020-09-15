using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Music", gameObject);
    }


    public static void PlaySoundFX(string nameEvent, GameObject go)
    {
        AkSoundEngine.PostEvent(nameEvent, go);
    }
}
