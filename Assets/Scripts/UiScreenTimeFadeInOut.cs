using UnityEngine;

public class UiScreenTimeFadeInOut : UiScreen
{
    public float timeFadeIn;
    public float timeFadeOut;
    public  void OpenScreen()
    {
        //      if(canvas.CanOpenNextScreen)
        canvas.FadeIn(timeFadeIn);
    }

    public  void CloseScreen()
    {
          
        canvas.FadeOut(timeFadeOut);   
    }
}