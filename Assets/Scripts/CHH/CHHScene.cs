using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHHScene : MonoBehaviour
{
    void Start()
    {
        if (Main.ResourceManager.Loaded)
        {
            Main.DataManager.Initialize();
        }
        else
        {
            Main.ResourceManager.LoadAllAsync<UnityEngine.Object>("PreLoad", (key, count, totalCount) =>
            {
                Debug.Log($"[TestScene] Load asset {key} ({count} / {totalCount})");
                if (count >= totalCount)
                {
                    Main.DataManager.Initialize();
                    //Main.Game.Initialize();
                    InitializeGame();
                }
            });
        }
    }

    private void InitializeGame()
    {
        

      
        Main.ObjectManager.Spawn<Enemy>("Blue", new(7, 2));
        Main.ObjectManager.Spawn<Enemy>("Black", new(7, 1));
        
    }
}
