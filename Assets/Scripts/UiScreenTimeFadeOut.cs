using UnityEngine;

public class UiScreenTimeFadeOut : UiScreen
{
    public float timeFadeOut;
   
    public  void OpenScreen()
    {
        //      if(canvas.CanOpenNextScreen)
        canvas.FadeIn();
    }

    public  void CloseScreen()
    {
          
        canvas.FadeOut(timeFadeOut);   
    }
}