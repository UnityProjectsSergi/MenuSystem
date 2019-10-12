using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UiSystem : MonoBehaviour
{

    #region Variables In GameMenu

    

    #endregion
    [Header(
        "To put IN GAME MENU mode have to put all canvas in world space Render Mode and have more than 1 Canvas inside of UiSystem gameObj Script  ")]
    [Header("InGameMenu Properites")]
    /// <summary>
    /// bool indicates is IN Game Menu with moviment of camera and only have one unity scene because the menu is ingame.
    /// </summary> 
    public bool IsInGameMenu;

    [SerializeField]
    /// <summary>
    /// bool indicates the movement of the camera is lerped
    /// </summary>
    private bool LerpMovimentCaamera;
    [SerializeField]

    private Camera mainCamera;
    private Transform OrinTranform;
    private Canvas currentCanvas;
    private Canvas previousCanvas;
    
    public static bool CanOpenNextScreen = true;
    public bool canSwitchscreen;

    [SerializeField]
    /// <summary>
    /// privte currentScreeen
    /// </summary>
    private UiScreen currentScreen;

    public List<Canvas> listPrevCanvas;
    public List<UiScreen> listPrevScreens;
    public int numPrvevScreen;
    public Color BGScreensColor;
    private UiScreen previousScreen;
    public bool SavePathOfScreensToGoPrev;

    // Start is called before the first frame update
    public Component[] screens = new Component[0];

    // Start is called before the first frame update
    public UiScreen startScreen;

    /// <summary>
    /// public Previuos Screen
    /// </summary>
    public UiScreen PreviousScreen
    {
        get { return previousScreen; }
    }

    /// <summary>
    /// public currrent screen
    /// </summary>
    [SerializeField]
    public UiScreen CurrentScreen
    {
        get { return currentScreen; }
    }

    public bool isd;
    void Start()
    {
        numPrvevScreen = 0;
        screens = GetComponentsInChildren<UiScreen>(true);
        if (SavePathOfScreensToGoPrev)
            listPrevScreens = new List<UiScreen>();
        InitiaizeScreens();
        if (!isd && startScreen  )
        {
            isd = true;
            StartCoroutine(SwitchScreen(startScreen));
        }
    }

    private void InitiaizeScreens()
    {
        foreach (UiScreen screen in screens)
        {
            screen.Reset();
        }
    }

    // Update is called once per frame
    void Update()
    {
      // if(canSwitchscreen)
            
      //  if (Inputs.Instance.GetUiBackButton()) GoToPreviousScreen();
    }
    /// <summary>
    /// Public SwiychScreen Methodh
    /// </summary>
    /// <param name="newScreen">New Screen to Open</param>
    /// <param name="Action"></param>
    /// <param name="fadeToBlack"></param>
    /// <param name="timeInFadeBlack"></param>
    public void CallSwitchScreen(UiScreen newScreen, UnityAction Action = null, bool fadeToBlack = false,
        float timeInFadeBlack=0.0f)
    
    {
        if (canSwitchscreen)
            StartCoroutine(SwitchScreen(newScreen, Action, fadeToBlack,timeInFadeBlack));
    }

    private IEnumerator SwitchScreen(UiScreen newScreen, UnityAction Action = null, bool fadeInOutBlack = false,
        float timeInFadeBlack=0.0f)
    {
        if (newScreen)
        {
            canSwitchscreen = false;
            if (SavePathOfScreensToGoPrev)
            {
                listPrevScreens.Add(newScreen);
                numPrvevScreen++;
            }

            if (currentScreen)
            {
                currentScreen.CloseScreen(fadeInOutBlack);

                if (!SavePathOfScreensToGoPrev)
                    previousScreen = currentScreen;


               
            }
            yield return new WaitForSeconds(timeInFadeBlack);

            currentScreen = newScreen;

            currentScreen.OpenScreen(Action, fadeInOutBlack);
            canSwitchscreen = true;
        }
    }

    public IEnumerator SwitchScreenPrev(UiScreen aScreen, UnityAction nae = null, bool fadeToBlack = false)
    {
        //if pass an screen
        if (aScreen)
        {
            canSwitchscreen = false;
            // if current screen is set
            if (currentScreen)
            {
                //if IsINGameMenu is true


                // Close current canvas
                currentScreen.CloseScreen(fadeToBlack);
                // set previousScreen with currentScreen
            }

            yield return new WaitForSeconds(currentScreen.fadeOutTime);
            //set currentScreen with newScren
            currentScreen = aScreen;
            // set active true current screenn
            currentScreen.gameObject.SetActive(true);

            currentScreen.OpenScreen(nae, fadeToBlack);
            canSwitchscreen = true;
        }
    }

    public void GoToPreviousScreen()
    {
        if(canSwitchscreen){
        // if theres a prevous screen
        if (SavePathOfScreensToGoPrev)
        {
            // reduce num od PrevSceen
            if (numPrvevScreen > 1)
            {
                numPrvevScreen--;
                // get prevoius screen from list
                previousScreen = listPrevScreens[numPrvevScreen - 1];
                //remove
                listPrevScreens.RemoveAt(numPrvevScreen);
                // call SwitchScreen
                StartCoroutine(SwitchScreenPrev(previousScreen));
            }
        }
        else
        {
            if (previousScreen)
            {
                StartCoroutine(SwitchScreenPrev(previousScreen));
            }
        }
    }
}}