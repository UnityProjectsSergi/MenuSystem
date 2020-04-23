using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {
    public Image ImageLevel;
    public Text textLevelName;
    public Text descriptioLevel;
    public bool isLocked;
    public Image isLockedImg;
    public Button btnLoadLevel;
	// Use this for initialization
	void Start () {
		
	}
	public void Init(AllLevelsData data)
    {
        ImageLevel.sprite = data.LevelSprite;
        textLevelName.text = data.LevelTitle;
        descriptioLevel.text = data.LevelDescription;
        isLocked = data.isLocked;
        
        if(isLocked)
        {
            isLockedImg.gameObject.SetActive(true);
            btnLoadLevel.gameObject.GetComponent<Button>().interactable = false;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
