using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objdataGO : MonoBehaviour
{

    public TestSO tstoso;
    // Start is called before the first frame update
    public int posX, PosY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(ObjData dataObjdata)
    {
        PosY = dataObjdata.PosY;
        posX = dataObjdata.posX;
    }

    public ObjData Getinfo()
    {
        ObjData ivh=new ObjData();

        ivh.posX = posX;
        ivh.PosY = PosY;
        return ivh;
    }
}
[System.Serializable]
public class ObjData
{
    public int posX, PosY;
}
