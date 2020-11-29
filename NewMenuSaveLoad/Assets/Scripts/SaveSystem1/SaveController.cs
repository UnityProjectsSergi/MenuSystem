
using SaveSystem1.DataClasses;
using UnityEngine;
using System.Linq;

using Assets.SaveSystem1.DataClasses;
using Newtonsoft.Json;

using RestClient.Core;
using RestClient.Scripts.Core.Models;

public class SaveController : Singleton<SaveController>
{

   
  
    

    public  Response _response=new Response();
    
    public  Response SaveNewUser(UserData user)
    {
        Response response=new Response();
        if (GameController.Instance.globalSettignsMenuSC.saveSystemSettings.saveSourceData == SaveSystemSourceData.Local)
        {
            if(SaveData.usersList.listUsers.Any(item=>item.Username==user.Username ))
            {
                _response.Error = "Usernam Exists";
                _response.StatusCode = 2;
                // return messag exists usrname
                return response;
            }
            else
            {
                SaveData.usersList.listUsers.Add(user);
                GameController.SaveGame();
                _response.Error = "";
                _response.StatusCode = 0;
                return response;
            }
        }
        else
        {
            Instance.StartCoroutine(RestWebClient.Instance.HttpPost("http://localhost/login",JsonUtility.ToJson(user),(_response)=>OnCompleteSaveNewUser(response)));
            return response;
        }
    }

    public Response  OnCompleteSaveNewUser(Response response)
    {
        return response;
    }
    public  Response GetUser(CheckUserData user)
    {
        if (GameController.Instance.globalSettignsMenuSC.saveSystemSettings.saveSourceData == SaveSystemSourceData.Local)
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
                _response.DataText = null;
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
        Instance.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/api/GetGameData",(r)=>
            {
                Debug.Log(r.StatusCode+"  "+r.Error);
                if (r.StatusCode == 410 || r.StatusCode == 500)
                {
                    SaveData.objcts = new GameDataSaveContainer();
                    Debug.Log("sergi "+SaveData.objcts);
                }
                else
                {
                    SaveData.objcts = JsonConvert.DeserializeObject<GameDataSaveContainer>(r.DataText);
                }

                GameController.Instance.dataExists = true;

            }));
    }
    public void CheckConnection(MonoBehaviour jutCo)
    {
        
        jutCo.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/api/GetGameDaya", (r) =>
        {
            bool check= (r.StatusCode == 200) ? true : false;
            if (check)
            {
                Debug.Log("CheckConnectionok");
                Debug.Log("Data ok"+r.DataText);
            }
            else
            {
                Debug.Log("failed connection");
                Debug.Log("Data error"+r.Dataobj+"  "+r.DataText);
            }
        }));
    }

    public void LoadSaveSlotWeb()
    {
        Instance.StartCoroutine(RestWebClient.Instance.HttpGet("http://localhost:8080/api/v2/slot/1", (r) =>
        {
            if (r.StatusCode == 200)
            {
            //  GameSlot AUX2= JsonUtility.FromJson<GameSlot>(r.Data);
                GameSlot aux = JsonConvert.DeserializeObject<GameSlot>(r.DataText);
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
