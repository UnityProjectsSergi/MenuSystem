using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreenController : MonoBehaviour
{
    public float Heath;

    public TMP_Text Health;

    public Button btn;

    public CanvasGroup SaveGameImage;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => CreateOjOnButtonPress());
    }

    // Update is called once per frame
    void Update()
    {
        LodGamePlayVars();
     
    }

    public void LodGamePlayVars()
    {
        if (GameController.Instance.currentSlot!=null)
        {
            Heath = GameController.Instance.currentSlot.health;
            Health.text = Heath.ToString(CultureInfo.CurrentCulture);
        }

   
        
    }

    public void ShowImageSavedGame()
    {
        StartCoroutine(ShowHideSaveCanvas(1.5f));
    }

    IEnumerator ShowHideSaveCanvas(float time)
    {
        StartCoroutine( FadeEffect.FadeCanvas(SaveGameImage, SaveGameImage.alpha, 1, 0.5f));
        yield return new WaitForSeconds(time);
        StartCoroutine( FadeEffect.FadeCanvas(SaveGameImage, SaveGameImage.alpha, 0, 0.5f));
    }

    public void CreateOjOnButtonPress()
    {
        Debug.Log("create obj frook screen controller");
        Instantiate(new GameObject("new from controller screen"));
    }

}
