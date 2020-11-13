﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DificultySlectionController : MonoBehaviour
{
    [Header("The list ")]
    
    
 
    
    public GameObject ParntOb;
    public GameObject buttonPrfab;
    public MenuController menuController;
    private UiScreen OwnScreen;
    // Use this for initialization
    void Start()
    {
        OwnScreen = GetComponent < UiScreen>();
        int i = 0;
        foreach (var item in GameController.Instance.globalSettignsMenuSC.screenSettings.listsOfDificulties)
        {
            if (item != "None")
            {
                GameObject go = Instantiate(buttonPrfab, transform.position, transform.rotation);
                go.transform.SetParent(ParntOb.transform);
             
                go.GetComponentInChildren<TMP_Text>().text = GameController.Instance.globalSettignsMenuSC.screenSettings.listsOfDificulties[i];
                i++;
                go.GetComponent<RectTransform>().offsetMax=new Vector2(4,5);
                go.GetComponent<RectTransform>().offsetMin=new Vector2(40,50);
                go.GetComponent<RectTransform>().sizeDelta=new Vector2(200,40);
                go.GetComponent<Button>().onClick.AddListener(() => SelectLevelDificulty(i));
                OwnScreen.UiElements.Add(go);
            }
        }
    }

    // Update is called once per frame
    
    public void SelectLevelDificulty(string level) {
        GameController.Instance.currentSlotResume.dataInfoSlot.gameDifficultyStr = level;
        menuController.IsUsingOneSlot();
    }
    public void SelectLevelDificulty(int level) {
        string gameDificulty= GameController.Instance.globalSettignsMenuSC.screenSettings.listsOfDificulties[level];
        GameController.Instance.currentSlotResume.dataInfoSlot.gameDifficultyStr = gameDificulty;
        menuController.IsUsingOneSlot();
    }
}
