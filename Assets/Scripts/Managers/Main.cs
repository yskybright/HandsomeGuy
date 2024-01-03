using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Main : MonoBehaviour
{
    private static Main s_instance;
    private static Main Instance
    {
        get { Init(); return s_instance; }
    }

    private ResourceManager _resourceManager = new ResourceManager();
    private UIManager _uiManager = new UIManager();

    public static UIManager UIManager { get { return Instance._uiManager; } }
    public static ResourceManager ResourceManager { get { return Instance._resourceManager; } }

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
