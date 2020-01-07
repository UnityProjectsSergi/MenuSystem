using System;
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
#if WWISE
        string className = "AkSoundEngine";
        Type type = Type.GetType(className);

        if (type != null)
        {
            AKRESULT res = AkSoundEngine.SetRTPCValue(_nameBus, value);
            if (res == AKRESULT.AK_Success)
            {
                return true;
            }
            else
            {
                      
                throw new ExceptionSound("Errror on Name of RTCP PArameter"+_nameBus);

            }
        }
        else
        {
            //Todo Throw exepcion
            //throw
            return false;
        }
#else
        throw new ExceptionSound("Not has the WWISE DEFINED");
       
#endif
    }

    public float GetValueBus(GameObject gameObject, int type)
    {
        #if WWISE
        string className = "AkSoundEngine";
        Type typec = Type.GetType(className);
        if (typec != null)
        {
            AKRESULT m = AkSoundEngine.GetRTPCValue(_nameBus, gameObject, 0, out var res, ref type);
            if (m == AKRESULT.AK_Success)
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
        //Todo Throw exepcion
        //throw
        return 0;
        #else
        throw new ExceptionSound("Not has the FMOD DEFINED");
    
        
        
#endif
    }
}
