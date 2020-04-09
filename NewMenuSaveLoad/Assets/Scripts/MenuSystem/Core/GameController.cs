using Assets.SaveSystem1.DataClasses;
using System.Collections;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    #region  Variables
    /// <summary>
    /// SettignsMenu 
    /// </summary>
        public SettignsMenu settignsMenu;
        /// <summary>
        /// Path of the file to save data
        /// </summary>
        public static string datapath = string.Empty;
        /// <summary>
        /// Says if The game was loaded or not loaded
        /// </summary>
        public static bool hasLoadedGameData = false;
        /// <summary>
        /// Current GameSlot Loaded in Game
        /// </summary>
        [CanBeNull] public GameSlot currentSlot = null;
        /// <summary>
        /// Says if file Esxists
        /// </summary>
        public bool fileExists;
        /// <summary>
    /// Test Do ad game obj to scene
    /// </summary>
        [CanBeNull]public GameObject _prefab;
        /// <summary>
        /// Instance Private of Game Controller
        /// </summary>
        private static GameController _instance = null;
        /// <summary>
        /// Current Slot Resume loaded
        /// </summary>
        [CanBeNull] public  InfoSlotResume currentSlotResume=null;

        [FormerlySerializedAs("hasCurrentSlotLoaded")] public bool hasCurrentSlot;
        /// <summary>
        /// Instace public of GameConstroller
        /// </summary>
        public static GameController Instance
        {
            get { return _instance; }
        }
        /// <summary>
        /// Save Interval Coroutine to save slot game on gameplay mode.
        /// </summary>
        [CanBeNull] private IEnumerator _saveIntervalCoroutine = null;
        [HideInInspector]
        public PauseController pauseController;
        public UiScreen gamePlayScreen;
    #endregion
    #region Methods
         #region UnityMetdods
              /// <summary>
            /// Start Unity Me
            /// </summary>
              private void Start()
              {
                  // set null currentSlotResume property on Start
                  currentSlotResume= null;
              }
              /// <summary>
              /// Awakw Unity Method
              /// </summary>
              private void Awake()
                {
                // Singleton Pattern
                if (_instance != null && _instance != this)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    // On first load 
                    currentSlot = null;
                    currentSlotResume = null;
                    _instance = this;
                    DontDestroyOnLoad(this.gameObject);
                    
                    datapath = System.IO.Path.Combine(Application.persistentDataPath, "data2.json");
                    fileExists = File.Exists(datapath);
                    pauseController = GetComponent<PauseController>();
                    // Load Data from Anywhere
                    Load(false);
                    

                }
            }
              /// <summary>
              /// On app qut
              /// </summary>
              private void OnApplicationQuit()
              {
                  currentSlotResume = null;
              }
              /// <summary>
              /// Update Metod Unity for Testing
              /// </summary>
              private void Update()
              {
                  /*if (Input.GetKeyDown(KeyCode.S))
                  {
                      Debug.Log("SAVE");
                      Save();
                  }
                  if (Input.GetKeyDown(KeyCode.D))
                  {
                      SaveSlotObj(); 
                  }
                  if (Input.GetKeyDown(KeyCode.L))
                  {
                      Debug.Log("Load");
                      Load();
                  }
                  if(Input.GetKeyDown(KeyCode.K))
                  {
                      //SaveData.LoadGameSlotData();
                  }
                  if (Input.GetKeyDown(KeyCode.C))
                  {
                      Debug.Log("Create");
                      CreateGameObject(_prefab, new Vector3(2, 5, 0), Quaternion.identity);
                  }*/
              }
        #endregion
        
        #region GameObjectsManagmentMetods
            /// <summary>
            /// Create GameObject in scene
            /// </summary>
            /// <param name="prefab">Prefab </param>
            /// <param name="position">Position of gameobject</param>
            /// <param name="rotation">Rotatio of gameobject</param>
            /// <returns></returns>
            public static ObjToSave CreateGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
            {
                // instanciate the object
                GameObject go = Instantiate(prefab, position, rotation);
                // get Component ObjToSave
                ObjToSave obj = go.GetComponent<ObjToSave>();
                // if obj is null
                if (obj == null)
                    // Add ObjToSaveComponent
                    go.AddComponent<ObjToSave>();
                return obj;
            }

            /// <summary>
            /// Create Game Object that has been saven on file
            /// </summary>
            /// <param name="data">Object Data from file</param>
            /// <param name="position">Position from file</param>
            /// <param name="rotation">Rrotation from file</param>
            /// <returns></returns>
            public static ObjToSave CreateObjSaved(GameObjectActorData data)
            {
                ObjToSave obj = CreateGameObject(Resources.Load<GameObject>(data.__prefabPath), data.position, data.rotationQuaterion);

                obj.gameObjSave.data = data;
                return obj;
            }
        #endregion
        #region Save Load Metdods
        /// <summary>
        /// Forces the load data
        /// </summary>
        public static void LoadForce()
        {
            SaveData.Load(datapath);
        }
        /// <summary>
        /// Load Function Loads data if hasLoaded dataes false at init
        /// </summary>
        public static void Load(bool force)
        {
            // if hasLoadedGameData is false
            if (!hasLoadedGameData)
            {
                // set HasLoadedGameData true
                hasLoadedGameData = true;
                // load data
                SaveData.Load(datapath);
                
            }
        }
        /// <summary>
        /// Save Data to file.
        /// </summary>
        public static void Save()
        {
           SaveData.SaveToFile<GameDataSaveContainer>(datapath, SaveData.objcts, true);
        }
        /// <summary>
        /// Save data of slot game to file
        /// </summary>
        public static void SaveSlotObj()
        {
            // save slot data from current slot data
            SaveData.SaveSlotData<GameSlot>(GameController.Instance.currentSlotResume.FileSlot, GameController.Instance.currentSlot, true);
        }
        #endregion

        #region  Other Methods
        /// <summary>
        /// Take Screen Shoot of Current Screen
        /// </summary>
        public void TakeScreenShot(bool save)
        {
            // get the path of currentSlotResume Folder 
            string path = Application.persistentDataPath + "/" + GameController.Instance.currentSlotResume.FolderOfSlot +
                          "/Sheen.png";
            // If not exists File 
            if (!File.Exists(Application.persistentDataPath + "/" + GameController.Instance.currentSlotResume.FolderOfSlot +
                             "/ScreenShot.png"))
            {
                // Take ScreenShoot
                ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + GameController.Instance.currentSlotResume.FolderOfSlot + "/ScreenShot.png");
                // Save Path of ScreenShoot 
                GameController.Instance.currentSlotResume.dataInfoSlot.ScreenShot = Application.persistentDataPath
                                                                       + "/" + GameController.Instance.currentSlotResume
                                                                           .FolderOfSlot + "/ScreenShot.png";
                // is save data
                if (save)
                {
                    // save 
                    GameController.Save();
                }
            }

        }
        /// <summary>
        /// call take screenshot with delay
        /// </summary>
        /// <param name="time">Time to wait to take screen shot</param>
        /// <param name="saveIt"> Say if needs to save it immediately</param>
        public void CallTakeScreenShotOnDelay(float time,bool saveIt)
        {
            StartCoroutine(TakeScreenShoot(time,saveIt));
        }
        /// <summary>
        /// Coroutine of TakeScreenShoot of Screen in time seconds
        /// </summary>
        /// <param name="time"></param>
        /// <returns>IEnuperator Coroutine</returns>
        public IEnumerator TakeScreenShoot(float time,bool saveIt)
        {
                // wait for time
               yield return new WaitForSecondsRealtime(time);
               // take screenshot 
               TakeScreenShot(saveIt);
        }
        /// <summary>
        /// Call Start Save Slot interval Coroutine
        /// </summary>
        /// <param name="intervalOfTime"></param>
        public void CallStartSaveSlotInterval(float intervalOfTime)
        {
            // get Coroutine
            _saveIntervalCoroutine = SaveSoltInterval(intervalOfTime);
            // start Coroutine
            StartCoroutine(_saveIntervalCoroutine);
        }

        /// <summary>
        /// Call Stop Save Slot interval Coroutine
        /// </summary>
        public void CallStopSaveSlotInterval()
        {
            /// check if is set 
            if (_saveIntervalCoroutine != null)
            {
                // stop doing the couroitne save interval
                StopCoroutine(_saveIntervalCoroutine);
                // set corotine null
                _saveIntervalCoroutine = null;
            }
        }

        /// <summary>
        /// Start Save Slot interval IEnumerator
        /// </summary>
        IEnumerator SaveSoltInterval(float time)
        {
            // infitint
            while (true)
            {
                // wait for time
                    yield return  new WaitForSecondsRealtime(time);
                    //save slot data
                    SaveSlotObj();
                    // show iu element for saved data
                    gamePlayScreen.GetComponent<GamePlayController>().ShowImageSavedGame();
            }
        }
        #endregion
    #endregion
    #region Unused Metdods
    public static T GetOrAddComponent<T>(GameObject obj) where T : Component
    {
        if (obj.GetComponent<T>())
            return obj.GetComponent<T>();
        else
            return obj.AddComponent<T>() as T;
    }


    #endregion
}


