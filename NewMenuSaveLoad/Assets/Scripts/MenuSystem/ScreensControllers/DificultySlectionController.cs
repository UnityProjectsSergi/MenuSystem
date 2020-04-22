using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultySlectionController : MonoBehaviour
{
    [Header("The list ")]
    
    public string[] str;
    public GameObject ParntOb;
    public GameObject buttonPrfab;
    public MenuController menuController;

    private UiScreen OwnScreen;
    // Use this for initialization
    void Start()
    {
        OwnScreen = GetComponent < UiScreen>();
        str = EnumConverter.ToNameArray<GameDifficulty>();
        foreach (var item in str)
        {
            if (item != "None")
            {
                GameObject go = Instantiate(buttonPrfab, transform.position, transform.rotation);
                go.transform.SetParent(ParntOb.transform);
                go.GetComponentInChildren<Text>().text = item;
                go.GetComponent<Button>().onClick.AddListener(() => SelectLevelDificulty(item));
                OwnScreen.UiElements.Add(go);
            }
        }
    }

    // Update is called once per frame
    
    public void SelectLevelDificulty(string level) {
        GameDifficulty gameDifficulty = (GameDifficulty)System.Enum.Parse(typeof(GameDifficulty), level);
        GameController.Instance.currentSlotResume.dataInfoSlot.gameDifficulty = gameDifficulty;
        menuController.IsUsingOneSlot();
    }
}
