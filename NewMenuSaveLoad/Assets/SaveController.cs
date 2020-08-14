using System;
using System.Collections;
using System.Collections.Generic;
using SaveSystem1.DataClasses;
using UnityEngine;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Assets.SaveSystem1.DataClasses;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Utilities;
using RestClient.Core;
using RestClient.Scripts.Core.Models;

public class SaveController : Singleton<SaveController>
{

   
  ///////////////// [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    

    public  Response _response=new Response();
    public static Response data;
    public  Response SaveNewUser(UserData user)
    {
        
        if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
        {
           
            if(SaveData.usersList.listUsers.Any(item=>item.Username==user.Username ))
            {
                _response.Error = "Usernam Exists";
                _response.StatusCode = 2;
                // return messag exists usrname
                return _response;
            }
            else
            {
                SaveData.usersList.listUsers.Add(user);
                GameController.SaveGame();
                _response.Error = "";
                _response.StatusCode = 0;
                return _response;
            }
        }
        else
        {
            //nstance.StartCoroutine(RestWebClient.Instance.HttpPost("http://localhost/login",JsonUtility.ToJson(user),(r)=>OnCompleteSaveNewUser(r)));
        }

        return null;
    }

    public static void OnCompleteSaveNewUser(Response response)
    {
            
    }
    public  Response GetUser(CheckUserData user)
    {
        if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
        {
         UserData userGet =  SaveData.usersList.listUsers.Where((m => m.Username == user.identifier && m.password == user.password)).Single();
         
            if (userGet != null)
            {
                _response.Error = "";
                _response.Dataobj = userGet;
                _response.StatusCode = 0;
            }
            else
            {
                _response.Error = "Error";
                _response.Data = null;
                _response.Dataobj = null;
                _response.StatusCode = 1;
            }
            return _response;
        }
        else
        {
         //   _instance.StartCoroutine(RestWebClient.Instance.HttpPost("http://localcost", JsonUtility.ToJson(user),(r)=>
            /*
            {
                _response = r;
            },null));
            */
            
        }
    // ls as d 
    // l
        return null;
    }

    public  void GetGame()
    {
        Instance.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/GetGameData",(r)=>
            {
                Debug.Log(r.StatusCode+"  "+r.Error);
                if (r.StatusCode == 410 || r.StatusCode == 500)
                {
                    SaveData.objcts = new GameDataSaveContainer();
                    Debug.Log("sergi "+SaveData.objcts);
                }
                else
                {
                    SaveData.objcts = JsonConvert.DeserializeObject<GameDataSaveContainer>(r.Data);
                }

                GameController.Instance.dataExists = true;

            }));
    }
    public void CheckConnection(MonoBehaviour jutCo)
    {
        
        jutCo.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/test", (r) =>
        {
            // = (r.StatusCode == 200) ? true : false;
            Debug.Log("CheckConnection");
        }));
    }

    public void LoadSaveSlotWeb()
    {
        Instance.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/api/v2/slot/1", (r) =>
        {
            if (r.StatusCode == 200)
            {
            //  GameSlot AUX2= JsonUtility.FromJson<GameSlot>(r.Data);
                GameSlot aux = JsonConvert.DeserializeObject<GameSlot>(r.Data);
                SaveData.LoadGameSlotDataToScene(aux);
            }
        }));
    }
    public void SaveGameSlot(object CONTENT)
    {
        Instance.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/api/v1/slot",(re)=>
        {
            if (re.StatusCode == 200)
                Instance.StartCoroutine(RestWebClient.Instance.HttpPut(
                    "http://localhost:8080/api/v1/slot/{" + ((GameSlot) CONTENT).id.ToString() + "}", CONTENT.ToString(),
                    (r) => { }));
            else
                Instance.StartCoroutine(RestWebClient.Instance.HttpPost(
                    "http://localhost:8080/api/v1/slot", CONTENT.ToString(),
                    (r) => { }));
            // fer post
        }));
    }

    public void SaveGame(object content)
    {
        Instance.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/api/v1/gameData",(re)=>
        {
            if (re.StatusCode == 200)
                Instance.StartCoroutine(RestWebClient.Instance.HttpPut(
                    "http://localhost:8080/api/v1/gameData/{" + ((GameSlot) content).id.ToString() + "}", content.ToString(),
                    (r) =>
                    {
                        
                        
                    }));
            else
                Instance.StartCoroutine(RestWebClient.Instance.HttpPost(
                    "http://localhost:8080/api/v1/gameData", content.ToString(),
                    (r) =>
                    {
                        
                    }));
            // fer post
        }));   
    }
}
