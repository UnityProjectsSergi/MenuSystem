using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    /// <summary>
    /// Says if LevelSelection ui is a list of levels or is a slider with button to change level
    /// </summary>
    public bool IsListGenerated;
    [Header("UI References")]
    /// <summary>
    /// Title of Level Text
    /// </summary>    
    public Text LevelTitleText;
    /// <summary>
    /// Descripcion of Level Text
    /// </summary>
    public Text LevelDescriptionText;
    /// <summary>
    /// Image of Level Image
    /// </summary>
    public Image LevelImage;
    [Header("Menu References")]
    /// <summary>
    /// 
    /// </summary>
    public UiScreen DificutySelection;
    /// <summary>
    /// 
    /// </summary>
    public UiSystem System;
    /// <summary>
    /// 
    /// </summary>
    public MenuController menuController;
    /// <summary>
    /// 
    /// </summary>
    public GameObject GenList, NoGenList;
    [Tooltip("Level Select Items will be here!")]
    /// <summary>
    /// 
    /// </summary>
    public Transform levelItemsContainer;
    [Tooltip("Level Item Prefab")]
    /// <summary>
    /// 
    /// </summary>
    public GameObject LevelItemPrefab;

    public UiScreen ownScreen;
    
    [HideInInspector]
    /// <summary>
    /// 
    /// </summary>
    public List<AllLevelsData> AllLevelsData = new List<AllLevelsData>();
    /// <summary>
    /// 
    /// </summary>
    int _totalLevels;
    /// <summary>
    /// 
    /// </summary>
   public int _currentSelectedLevelCount=0;
    /// <summary>
    /// 
    /// </summary>
    string _currentSelectedLevelSceneName;
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        // Get Component MenuController
        ownScreen = GetComponent<UiScreen>();
        // if isListGenerated is false
        if (!IsListGenerated)
        {
            // Active NoGeneratedList GameObject
            NoGenList.SetActive(true);
            // Desactive GeneratedList GameOibject
            GenList.SetActive(false);
            //get all levels count
            // get count all Levels assing no interal _totalLevels 
            _totalLevels = AllLevelsData.Count;

            //init
            ChangeLevel();
          
        }
        // if isListGenerated istrue
        else
        {
            // Active GeneratedList GameObject
            GenList.SetActive(true);
            // Desctive NoGeneratedList GameObject
            NoGenList.SetActive(false);
            // call function Generate Lists of levels
            GenerateListsLevels();
        }
    }
    /// <summary>
    /// Generate lists of levels has in Array AllLevelsData with Editor
    /// </summary>
    public void GenerateListsLevels()
    {
        // loop in the array AllLevelsData
        foreach (var item in AllLevelsData)
        {
            // Instanciate New GameObject  
            GameObject ObjLevel = Instantiate(LevelItemPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            // Set the parameters of Each Level to Components Name  to Text Name, Description to Text Descripton
            ObjLevel.GetComponentInChildren<Text>().text = ObjLevel.name;
            ObjLevel.GetComponent<RectTransform>().offsetMax=new Vector2(4,5);
            ObjLevel.GetComponent<RectTransform>().offsetMin=new Vector2(40,50);
            ObjLevel.GetComponent<RectTransform>().sizeDelta=new Vector2(800,150);
            
            //Set Child of Container the ObjLevel 
            ObjLevel.transform.SetParent(levelItemsContainer.transform, false);
            // Get Script From 
            
            LevelUI level = ObjLevel.GetComponent<LevelUI>();

            if (level != null)
            {
                level.Init(item);
                if (!level.isLocked)
                {
                    level.btnLoadLevel.onClick.RemoveAllListeners();
                    level.btnLoadLevel.onClick.AddListener(() => LoadLevel(item));
                }
            }
            ownScreen.UiElements.Add(level.btnLoadLevel.gameObject);
            
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void LoadLevel(AllLevelsData level)
    {
        GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay = level.SceneToLoad;
        if (GameController.Instance.globalSettignsMenuSC.screenSettings.isDificultyLevelSelectionScreenEnabled)
        {
            System.CallSwitchScreen(DificutySelection);
        }
        else
        {
            GameController.Instance.currentSlotResume.dataInfoSlot.gameDifficulty = GameDifficulty.None;
            menuController.IsUsingOneSlot();
        }
         }
    /// <summary>
    /// 
    /// </summary>
    public void ChangeLevel()
    {
        if (!IsListGenerated && AllLevelsData.Count>0)
        {
            //set UI
            LevelTitleText.text = AllLevelsData[_currentSelectedLevelCount].LevelTitle;
            LevelDescriptionText.text = AllLevelsData[_currentSelectedLevelCount].LevelDescription;
            LevelImage.sprite = AllLevelsData[_currentSelectedLevelCount].LevelSprite;

            _currentSelectedLevelSceneName = AllLevelsData[_currentSelectedLevelCount].SceneToLoad;

            //increment count
            if (_currentSelectedLevelCount < _totalLevels - 1)
                _currentSelectedLevelCount++;
            else
                _currentSelectedLevelCount = 0;
        }
        else
        {
            
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void PlayLevel()
    {
        GameController.Instance.currentSlotResume.dataInfoSlot.currentLevelPlay = _currentSelectedLevelSceneName;
        if (GameController.Instance.globalSettignsMenuSC.screenSettings.isDificultyLevelSelectionScreenEnabled)
        {
            System.CallSwitchScreen(DificutySelection,null,false);
        }
        else
        {
            GameController.Instance.currentSlotResume.dataInfoSlot.gameDifficulty = GameDifficulty.None;
            GameController.Instance.currentSlotResume.dataInfoSlot.gameDifficultyStr = "None";
            menuController.IsUsingOneSlot(); 
        }
    }
}
[System.Serializable]
/// <summary>
/// 
/// </summary>
public class AllLevelsData
{
    public string LevelTitle;
    public string LevelDescription;
    public string SceneToLoad;
    public Sprite LevelSprite;
    public bool isLocked;
}
