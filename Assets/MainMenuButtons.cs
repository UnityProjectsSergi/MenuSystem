using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public void SetPauseMenu()
    {
        text.text = "PauseMenu";
        ResumeBtn.gameObject.SetActive(true);
        ExitMainMenuBtn.gameObject.SetActive(true);
        SaveGameBtn.gameObject.SetActive(true);
        ContinueBtn.gameObject.SetActive(false);
        NewGameBtn.gameObject.SetActive(false);
        LoadGameBtn.gameObject.SetActive(true);
    }
    public void SetMainMenu()
    {
        text.text = "MainMenu";
        ContinueBtn.gameObject.SetActive(true);
        ResumeBtn.gameObject.SetActive(false);
        ExitMainMenuBtn.gameObject.SetActive(false);
        SaveGameBtn.gameObject.SetActive(false);
        NewGameBtn.gameObject.SetActive(true);
    }
}
