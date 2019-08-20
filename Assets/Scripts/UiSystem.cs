using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class UiSystem : MonoBehaviour
{
    public UiScreen currentScreen;

    public UiScreen previousScreen;
    // Start is called before the first frame update
    public UiScreen startScreen;
    // Start is called before the first frame update
    void Awake()
    {
       StartCoroutine( SwitchScreen(startScreen));
    }

    public static bool CanOpenNextScreen=true
        ;
    private bool hascall = false;
    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.A) && !hascall) {  
           
            hascall = true;
        }
      //  if(Input.GetKeyDown(KeyCode.K)) SwitchScreen((startScreen));
    }
    public IEnumerator SwitchScreen(UiScreen newScreen,UnityAction nae=null)
    {
        if(newScreen)
        {
            if(currentScreen)
            {
                CanOpenNextScreen = false;
                currentScreen.CloseScreen();
                Debug.Log("close current screen"+currentScreen.name);
                previousScreen = currentScreen;
                yield return  new WaitForSeconds(currentScreen.fadeOutTime);
            }
            
          
                //     newScreen.gameObject.SetActive(false);
                currentScreen = newScreen;
                //   currentScreen.gameObject.SetActive(true);
                currentScreen.OpenScreen(nae);
                Debug.Log("open");
            

        }
    }

}
