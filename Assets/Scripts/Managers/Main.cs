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

    private UIManager _uiManager = new UIManager();

    public static UIManager UIManager { get { return Instance._uiManager; } }

    private void Start()
    {
        Init();

    }

    private void Update()
    {
        //_inputManager.OnUpdate();
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
