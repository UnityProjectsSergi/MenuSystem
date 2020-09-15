using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Assets.SaveSystem1.DataClasses;
using System.Reflection;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SaveSystem1.DataClasses;
using UnityEngine.PlayerLoop;

public class SaveData
{
    public static GameDataSaveContainer objcts = new GameDataSaveContainer();
    public static UsersContinerData usersList=new UsersContinerData();
    public delegate void SerializeAction();

    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

    public static void LoadFromUser()
    {
        
    }

    public static void SaveToUser()
    {
        
    }
    /// <summary>
    /// Load File data into memory And create the objects saved in file. 
    /// </summary>
    /// <param name="Path">Path of the file to load</param>
    public static void Load()
    {
        //Load From file 
        objcts = null;
        if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
            if (GameController.Instance.globalSettignsMenu.isUserLoginRegisterActive)
            {
                usersList = LoadFromFile<UsersContinerData>(GameController.datapath);
            }
            else
            {
                objcts = LoadFromFile<GameDataSaveContainer>(GameController.datapath);
            }
        else if(GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Remote)
        {
            if (!GameController.Instance.globalSettignsMenu.isUserLoginRegisterActive)
                 LoadFromWeb();
        }
    }
    private static void LoadFromWeb()
    {
        SaveController.Instance.GetGame();
    }
    
    /// <summary>
    /// Load Game FromSlot Obj 
    /// </summary>
    /// <param name="currentSlot"></param>
    public static void LoadGameSlotDataToScene(GameSlot currentSlot)
    {
        if (currentSlot.ObjectsToSaveInSlot.Count > 0)
        {
            foreach (var item in currentSlot.ObjectsToSaveInSlot.ToArray())
            {
                currentSlot.NumObj++;
                GameLevelController.CreateObjSaved(item);
            }
            // crido l'event aqut 
            OnLoaded();
            ClearGameObjectsListSlot();
        }
        GameController.Instance.currentSlot = currentSlot;
    }

    
    public void SaveGame<T>(string path_url,T content,bool deleteIfExistsFile)where T : new()
    {
        if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
        {
            SaveToFile<T>(path_url, content, deleteIfExistsFile);
        }
        else
        {
            //SaveToWebSlots<>();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">File name and the path in local storage</param>
    /// <param name="content">Object to save in the local storage</param>
    /// <param name="deleteIfExistsFile">bool says what to do if exists file 
    ///     if its true the file is deleted 
    ///     if its false the content is added at the end of old content  </param>
    /// 
    public static void SaveSlotData<T>(string path, T content, bool deleteIfExistsFile) where T : new()
    {
        if ((bool) GameController.Instance.hasCurrentSlot)
        {
            ObjToSave[] num = GameObject.FindObjectsOfType<ObjToSave>();
            if (num.Length != 0)
            {
                OnBeforeSave();
                if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
                {
                    SaveToFile<T>(path, content, deleteIfExistsFile);
                }
                else
                {
                    SaveToWebSlots(content);
                }
                ClearGameObjectsListSlot();
            }
            else
            {
                ClearGameObjectsListSlot();
                if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
                {
                    SaveToFile<T>(path, content, deleteIfExistsFile);
                }
                else
                {
                    SaveToWebSlots(content);
                }
            }
        }
    }
    private static void SaveToWebSlots<T>(T content) 
    {
        
        SaveController.Instance.SaveGameSlot(content);
    }
    /// <summary>
    /// Add GameObject data to the list of GameObjects Data
    /// </summary>
    /// <param name="data"></param>    
    public static void AddGameObjectData(GameObjectActorData data)
    {
        if ((bool) GameController.Instance.currentSlot)
        {
            GameController.Instance.currentSlot.NumObj++;
            GameController.Instance.currentSlot.ObjectsToSaveInSlot.Add(data);
        }
    }

    /// <summary>
    /// Clear the GameObjects List of Data
    /// </summary>
    public static void ClearGameObjectsListSlot(GameSlot currentSlot = null)
    {
        if ((bool) GameController.Instance.currentSlot)
            GameController.Instance.currentSlot.ObjectsToSaveInSlot.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of GameObject To Load</typeparam>
    /// <param name="path">Path and filename of the data to load</param>
    /// <returns></returns>
    public static GameSlot LoadFromSource<T>(string path)
    {
        GameSlot aux;
        if (GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Remote)
        {
             SaveController.Instance.LoadSaveSlotWeb();
             return GameController.Instance.currentSlot;
        }
        else if(GameController.Instance.globalSettignsMenu.saveSourceData == SaveSystemSourceData.Local)
        {
            return LoadFromFile<GameSlot>(GameController.Instance.currentSlotResume.FileSlot);
        }
        else
        {
            return null;
        }
        
    }
    public static T LoadFromFile<T>(string path) where T : new()
    {
        if (File.Exists(path))
        {
            T obj=new T();
            string json = File.ReadAllText(path);
            if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.JSON)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Xml)
            {
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                StringReader reader = new StringReader(json);
                return (T) serializer.Deserialize(reader);
            }
            else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Binnary)
            {
               return  BinarySerializer.Load<T>(path);
                BinaryFormatter formatter = new BinaryFormatter();
                // Open up a filestream, combining the path and object key
                FileStream fileStream = new FileStream(path , FileMode.Open);
                // Initialize a variable with the default value of whatever type we're using
                T returnValue = new T();
                /* 
                 * Try/Catch/Finally block that will attempt to deserialize the data
                 * If we fail to successfully deserialize the data, we'll just return the default value for Type
                 */
                try
                {
                    returnValue = (T)formatter.Deserialize(fileStream);
                }
                catch (SerializationException exception)
                {
                    Debug.Log("Load failed. Error: " + exception.Message);
                }
                finally
                {
                    fileStream.Close();
                }

                return returnValue;
            }
            return obj;
        }
        else
        {
            return new T();
        }
    }


    /// <summary>
    /// Save Game Objects and 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <param name="deleteIfExists"></param>
    public static void SaveToFile<T>(string path, T content, bool deleteIfExistsFile) where T : new()
    {
        // if file exists
        if (File.Exists(path))
        {
            // is exists deleted?
            if (deleteIfExistsFile)
            {
                //delete file and create wen
                File.Delete(path);
                // if file type format is json
                if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.JSON)
                {
                    //write to file
                    File.WriteAllText(path, JsonConvert.SerializeObject(content, Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
                }
                // if file type format is xml
                else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Xml)
                {
                    // write on xml
                    var stringwriter = new System.IO.StringWriter();
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    serializer.Serialize(stringwriter, content);
                    File.WriteAllText(path, stringwriter.ToString());
                }
                else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Binnary)
                {
                    
                    BinarySerializer.Save(content,path);
                    
                    /*
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(path ,FileMode.OpenOrCreate);
                   
                    bf.Serialize(file, content);
                    file.Close();*/
                }
            }
            // if exist and not delete
            else
            {
                // if file type format is json
                if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.JSON)
                {
                    // read the file and apped extra information
                    string json = File.ReadAllText(path);
                    //File.WriteAllText(path,json+ JsonUtility.ToJson(content));
                    Append(path, json + JsonConvert.SerializeObject(content, Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
                }
                // if file type format is xml
                else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Xml)
                {
                    // write on xml file
                    string xml = File.ReadAllText(path);
                    var stringwriter = new System.IO.StringWriter();
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    serializer.Serialize(stringwriter, content);
                    Append(path, xml + stringwriter.ToString());
                }
                else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Binnary)
                {
                    BinarySerializer.Save(content,path);
                    
                    /*
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(path ,FileMode.OpenOrCreate);
                   
                    bf.Serialize(file, content);
                    file.Close();*/
                }
                
            }
        }
        else
        // if not exists create and write file
        {
            // if file type format is json
            if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.JSON)
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(content, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
            }
            // if file type format is xml
            else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Xml)
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, content);
                File.WriteAllText(path, stringwriter.ToString());
            }
            else if (GameController.Instance.globalSettignsMenu.typeSaveFormat == SaveSystemFormat.Binnary)
            {
                BinarySerializer.Save(content,path);
                    
                /*
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path ,FileMode.OpenOrCreate);
               
                bf.Serialize(file, content);
                file.Close();*/
            }
        }
    }
    private static void Append(string path, string contents)
    {
        File.WriteAllText(path, contents);
    }

    public static void AddOBjectInScene(ObjToSave[] array)
    {
        foreach (var item in array)
        {
            GameController.Instance.currentSlot.ObjectsToSaveInSlot.Add(item.gameObjSave.data);
        }
    }

    private bool HasType(string typeName)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.Name == typeName)
                    return true;
            }
        }

        return false;
    }

    public static bool NamespaceExists(string desiredNamespace)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.Namespace == desiredNamespace)
                    return true;
            }
        }

        return false;
    }

    public static T[] ConcatArrays<T>(params T[][] list)
    {
        var result = new T[list.Sum(a => a.Length)];
        int offset = 0;
        for (int x = 0; x < list.Length; x++)
        {
            list[x].CopyTo(result, offset);
            offset += list[x].Length;
        }

        return result;
    }
}