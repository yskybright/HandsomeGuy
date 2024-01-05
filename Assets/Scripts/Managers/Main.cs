using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    private static Main s_instance;
    private static Main Instance
    {
        get { Init(); return s_instance; }
    }

    private ResourceManager _resourceManager = new ResourceManager();
    private UIManager _uiManager = new UIManager();
    private PoolManager _poolManager = new PoolManager();
    private ObjectManager _objectManager = new ObjectManager();
    private DataManager _dataManager = new DataManager();
    private SceneManagerEx _sceneManagerEx = new SceneManagerEx();
    private GameManager _gameManager = new GameManager();
    public static UIManager UIManager { get { return Instance._uiManager; } }
    public static ResourceManager ResourceManager { get { return Instance._resourceManager; } }
    public static PoolManager PoolManager { get { return Instance._poolManager; } }
    public static ObjectManager ObjectManager { get { return Instance._objectManager;} }
    public static DataManager DataManager { get { return Instance._dataManager;} }
    public static SceneManagerEx SceneManagerEx { get { return Instance._sceneManagerEx; } }
    public static GameManager GameManager {  get { return Instance._gameManager; } }
    private void Start()
    {
        Init();

    }

    private void Update()
    {

    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject gameObject = GameObject.Find("Managers");
            if (gameObject == null)
            {
                gameObject = new GameObject("Managers");
                gameObject.AddComponent<Main>();
            }
            DontDestroyOnLoad(gameObject);

            s_instance = gameObject.GetComponent<Main>();
        }

    }
}
