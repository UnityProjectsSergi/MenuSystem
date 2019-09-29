using UnityEngine;
public class RTPCWwise
{
    private readonly string _nameBus;
    public RTPCWwise(string nameBus)
    {
        _nameBus = nameBus;
    }

    public bool SetValueBus(float value)
    {
        AKRESULT res = AkSoundEngine.SetRTPCValue(_nameBus, value);
     
        if (res == AKRESULT.AK_Success)
            return true;
        else
        {
           
            return false;
        }
    }

    public float GetValueBus(GameObject gameObject,int type)
    {
        AKRESULT m = AkSoundEngine.GetRTPCValue(_nameBus, gameObject, 0, out var res, ref type);
        if (m==AKRESULT.AK_Success)
        {
            return res;
        }
        else
        {
            //Todo Throw exepcion
            //throw 
         
            return 0;
        }
    }
}
