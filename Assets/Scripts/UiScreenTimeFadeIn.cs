using UnityEngine;

public class UiScreenTimeFadeIn : UiScreen
{
    public float timeFadeIn;
      
    public  void OpenScreen()
    {
        Debug.Log(("sssssss"));
        //      if(canvas.CanOpenNextScreen)
        canvas.FadeIn(timeFadeIn);
    }

    public  void CloseScreen()
    {
          
        canvas.FadeOut();   
    }
}