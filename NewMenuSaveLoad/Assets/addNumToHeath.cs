using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addNumToHeath : MonoBehaviour
{
    public GamePlayScreenController gamePlayScreenController;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayScreenController = FindObjectOfType<GamePlayScreenController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.currentSlot!=null && GameController.Instance)
            if (!GameController.Instance.pauseController.isPausedGame)
                GameController.Instance.currentSlot.health += 0.005f * Time.deltaTime;

        // if (gamePlayScreenController.Heath > 1.5f)
        //     Instantiate(new GameObject("new from script in game scene"));

    }
}
