using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class SceneLoader
    {
        private static bool initialized = false;
[InitializeOnEnterPlayMode]
        // ensure you call this method from a script in your first loaded scene
        public static void Initialize()
        {
            if (initialized == false)
            {
                initialized = true;
                // adds this to the 'activeSceneChanged' callbacks if not already initialized.
               UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnSceneWasLoaded;
                UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnScenrLoaded;
            }
        }

        private static void OnScenrLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log("ssssssss");
            //GameController.Instance.InitGameSettingsLoad();
        }

        private static void OnSceneWasLoaded(UnityEngine.SceneManagement.Scene from,
            UnityEngine.SceneManagement.Scene to)
        {
            // do instantiate work here
            Debug.Log("ssssssssmmmmmm");
        }
    }
