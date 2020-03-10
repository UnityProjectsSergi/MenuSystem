public class SoundBusFMOD
{
    // puf FMOD Instance

#if FMOD
        if(Utils.NamespaceExists("FMOD"))
        {
            public FMOD.Studio.Bus instanceBus
        }
        else
        {
           
            throw new ExceptionSound("Not has the FMOD Scripts");
        }
#else
   
#endif
    // Start is called before the first frame update
    public SoundBusFMOD(string nameBus)
    {
#if FMOD
        if(Utils.NamespaceExists("FMODUnity"))
        {
              instanceBus = FMODUnity.RuntimeManager.GetBus("Bus:/" + nameBus);
        }
        else
        {
            throw new ExceptionSound("Not has the FMOD Scripts");
        }
#else
        throw new ExceptionSound("Not has the FMOD DEFINED");
#endif
    }


    public void SetBusVolume(float num)
    {
#if FMOD
        if(Utils.NamespaceExists("FMOD")){
            instanceBus.setVolume(num);
        }
        else
      throw new ExceptionSound("Not has the FMOD Scripts");
#else
        throw new ExceptionSound("Not has the FMOD DEFINED");
#endif
    }

    public float GetBusVolume()
    {
#if FMOD
        if(Utils.NamespaceExists("FMOD"))
        {
            return  instanceBus.getVolume();
        }
        else
         throw new ExceptionSound("Not has the FMOD Scripts");
#else
        
        throw new ExceptionSound("Not has the FMOD DEFINED");
        
#endif
       // return 0;
       
    }
}