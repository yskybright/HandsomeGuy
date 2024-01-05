using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public List<Projectile> Projectiles { get; private set; } = new();
    public PlayerData Player { get; private set; } = new();
    public List<Enemy> Enemies { get; private set; } = new();

    public T Spawn<T>(string key, Vector2 position) where T : MonoBehaviour
    {
        System.Type type = typeof(T);

        if (type == typeof(PlayerData))
        {
            GameObject obj = Main.ResourceManager.Instantiate("Player.prefab");
            obj.transform.position = position;
         
            Player = Main.DataManager.Player;
            return Player as T;
        }

        if (type == typeof(Enemy))
        {
            EnemyData data = Main.DataManager.Enemies[key];
            GameObject obj = Main.ResourceManager.Instantiate($"Enemy.prefab", pooling: true);
            obj.transform.position = position;

            Enemy enemy = obj.GetOrAddComponent<Enemy>();
            enemy.SetInfo(key);
            Enemies.Add(enemy);

            Debug.Log("fdsafdsaf");

            return Player as T;
        }
        //else if (type == typeof(Enemy))
        //{
        //    CreatureData data = Main.Data.Creatures[key];
        //    GameObject obj = Main.ResourceManager.Instantiate($"{data.prefabName}.prefab", pooling: true);
        //    obj.transform.position = position;

        //    Enemy enemy = obj.GetOrAddComponent<Enemy>();
        //    enemy.SetInfo(key);
        //    Enemies.Add(enemy);

        //    return enemy as T;
        //}
        return null;
    }

    public void Despawn<T>(T obj) where T : MonoBehaviour
    {
        //if (!obj.gameObject.IsValid()) return;
       
        if (obj is Projectile projectile)
        {
            Projectiles.Remove(projectile);
        }

        Main.ResourceManager.Destroy(obj.gameObject);
        System.Type type = typeof(T);

        if (type == typeof(Enemy))
        {
            Enemies.Remove(obj as Enemy);
            Main.ResourceManager.Destroy(obj.gameObject);
        }
    }
}