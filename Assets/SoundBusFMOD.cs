public class SoundBusFMOD
{
    // puf FMOD Instance

#if FMOD
        Debug.Log("sssssssssssssssss");
        if(Utils.NamespaceExists("FMOD")){
            public FMOD.Studio.Bus instanceBus
         }
#endif
    // Start is called before the first frame update
    public SoundBusFMOD(string nameBus)
    {
#if FMOD
        Debug.Log("sssssssssssssssss");
        if(Utils.NamespaceExists("FMOD")){
           
            
              instanceBus = FMODUnity.RuntimeManager.GetBus("Bus:/" + nameBus);
        }
        else
        {
            Debug.LogError("You Define FMOD Symbol but need import FMOD Pakage");
        }
#endif
    }


    public void SetBusVolume(float num)
    {
#if FMOD
        if(Utils.NamespaceExists("FMOD")){
            instanceBus.setVolume(num);
        }
#endif
    }

    public float GetBusVolume()
    {
#if FMOD
        if(Utils.NamespaceExists("FMOD")){
            return  instanceBus.getVolume();

        }
return 0;
#else
        //Todo Excepcon
        return 0;
#endif
    }
}