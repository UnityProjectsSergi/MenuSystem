using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {

    [SerializeField]
    /// <summary>
    /// Save Game Button  
    /// </summary>
    public Button SaveGameBtn;
    [SerializeField]
    /// <summary>
    /// Resume Game Button  
    /// </summary>
    public Button ResumeBtn;
    [SerializeField]
    /// <summary>
    /// New Game Button  
    /// </summary>
    public Button NewGameBtn;
    [SerializeField]
    /// <summary>
    /// Continue Game Button  
    /// </summary>
    public Button ContinueBtn;
    [SerializeField]
    /// <summary>
    /// Loading Game Button  
    /// </summary>
    public Button LoadGameBtn;
    [SerializeField]
    /// <summary>
    /// ExitMainMenu Game Button  
    /// </summary>
    public Button ExitMainMenuBtn;
    public Text text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetPauseMenu(SlotController slotController,int numSlots)
    {
        text.text = "Pause Menu";
        EventSystem.current.SetSelectedGameObject(ResumeBtn.gameObject);
        
        ResumeBtn.gameObject.SetActive(true);
        ExitMainMenuBtn.gameObject.SetActive(true);
		SaveGameBtn.gameObject.SetActive(true);	
        ContinueBtn.gameObject.SetActive(false);
        NewGameBtn.gameObject.SetActive(false);
		SetButtonaActiveDependSlots(slotController,numSlots);
		
    }

    public Navigation SetNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
    {
	    Navigation nav=new Navigation();
	    nav.selectOnDown = down;
	    nav.selectOnUp = up;
	    nav.selectOnLeft = left;
	    nav.selectOnRight = right;
	    return nav;
    }
    public void SetMainMenu(SlotController slotController,int numSlots)
    {
        text.text = "Main Menu";
        EventSystem.current.SetSelectedGameObject(ContinueBtn.gameObject);
        ContinueBtn.gameObject.SetActive(true);
        ResumeBtn.gameObject.SetActive(false);
        ExitMainMenuBtn.gameObject.SetActive(false);
        SaveGameBtn.gameObject.SetActive(false);
        NewGameBtn.gameObject.SetActive(true);
		SetButtonaActiveDependSlots(slotController,numSlots);
    }

    private void SetButtonaActiveDependSlots(SlotController slotController, int numSlots)
    {
	    if (slotController.isSlotsEnabled)
	    {
		    if (numSlots > 0)
		    {
			    // No activate LoadGmeBtn and 
			    LoadGameBtn.gameObject.SetActive(true);
			 
		    }
		    else
		    {
			    LoadGameBtn.gameObject.SetActive(false);
		    }
	    }
	    else
	    {
		    SaveGameBtn.gameObject.SetActive(false);
		    LoadGameBtn.gameObject.SetActive(false);
	    }

	 
    }
}
