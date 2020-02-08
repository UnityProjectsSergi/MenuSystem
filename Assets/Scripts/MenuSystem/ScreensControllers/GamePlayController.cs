using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public float Heath;

    public Text Health;

    // Start is called before the first frame update
    void Start()
    {

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


}
