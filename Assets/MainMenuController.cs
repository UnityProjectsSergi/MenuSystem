using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public MainMenuButtons MainMenuButtons;
    public MenuController MenuController;
    public loaderScene loadscene;
    public UiSystem UiSystem;
    public UiScreen Options;
    public UiScreen loderSfen;
    // Start is called before the first frame update
    void Start()
    {
        SetMainMenuWithSlots();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLoadGame()
    {
        UiSystem.CallSwitchScreen(loderSfen,delegate {     loadscene.FloaderScene(); },true);
    
    }

    public void OpenSettings()
    {
        UiSystem.CallSwitchScreen(Options,null,false);
    }
    public void SetMainMenuWithSlots()
    {
        // Active Main Menu Buttons
       
        MainMenuButtons.SetMainMenu();
        // if not have slots in list
        if (MenuController.slotController.isSlotsEnabled)
        {
            // If no has slots count
            if (SaveData.objcts.Slots.Count == 0)
            {
                // No activate LoadGmeBtn and 
                MainMenuButtons.LoadGameBtn.gameObject.SetActive(false);
            }
            // if have slot or slots in list
            else if (SaveData.objcts.Slots.Count >= 1)
            {
                // use One Only Slot is true
                if (!MenuController.slotController.useManySlots)
                {
                    // No activate LoadGameBtn
                    MainMenuButtons.LoadGameBtn.gameObject.SetActive(false);
                }
            }           
        }
        else
        {
            MainMenuButtons.LoadGameBtn.gameObject.SetActive(false);
        }
        if (SaveData.objcts.previousSlotLoaded == null)
        {
            MainMenuButtons.ContinueBtn.gameObject.SetActive(false);
        }
    }
}
