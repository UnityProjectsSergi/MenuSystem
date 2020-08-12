using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionSceenController : MonoBehaviour {
    public Button yesBtn;
    public Button noBtn;
    public Button cancelBtn;
    public TMP_Text questionText;
    public TMP_Text titleText;
    public KeyCode YesKey;
    public KeyCode NoKey;
    public KeyCode CancelKey;
    public bool isEnabledKeys;

	// Use this for initialization
	void Start () {
		
	}
	public void OpenModal(string title,string question,UnityEvent Yes=null,UnityEvent no=null , UnityEvent cancel=null )
    {
        isEnabledKeys = true;
        cancelBtn.onClick.RemoveAllListeners();
        yesBtn.onClick.RemoveAllListeners();
        cancelBtn.onClick.RemoveAllListeners();
        questionText.text = question;
        titleText.text = title;
        if (Yes == null)
            yesBtn.gameObject.SetActive(false);
        else
        {
            yesBtn.onClick.AddListener(delegate { Yes.Invoke();isEnabledKeys = false; });
            
        }

        if (no == null)
            noBtn.gameObject.SetActive(false);
        else
            noBtn.onClick.AddListener(delegate { no.Invoke(); isEnabledKeys = false; });
        if (cancel == null)
            cancelBtn.gameObject.SetActive(false);
        else
            cancelBtn.onClick.AddListener(delegate { cancel.Invoke(); isEnabledKeys = false; });
    }
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        Event e = Event.current;
        if (isEnabledKeys)
        {
            if (e.keyCode == YesKey && e.isKey && e.type == EventType.KeyDown)
            {
                yesBtn.onClick.Invoke();
            }
            if (e.keyCode == NoKey && e.isKey && e.type == EventType.KeyDown)
            {
                noBtn.onClick.Invoke();
            }
            if (e.keyCode == CancelKey  && e.isKey && e.type == EventType.KeyDown)
            {
                cancelBtn.onClick.Invoke();
            }
        }
    }
}
