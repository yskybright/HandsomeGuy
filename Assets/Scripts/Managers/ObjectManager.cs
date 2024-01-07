using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ObjectManager
{
    public List<Projectile> Projectiles { get; private set; } = new();
    public Player Player { get; private set; } = new();
    public List<Enemy> Enemies { get; private set; } = new();

    public T Spawn<T>(string key, Vector2 position) where T : MonoBehaviour
    {
        System.Type type = typeof(T);

        if (type == typeof(Player))
        {
            GameObject obj = PhotonNetwork.Instantiate("Prefabs/Player", position, Quaternion.identity);
            Debug.Log(PhotonNetwork.CurrentRoom.Players.Count);

            Player player = obj.GetOrAddComponent<Player>();
            PhotonView pv = player.GetComponent<PhotonView>();
           
            player.SetInfo(key);

            if (pv.IsMine)
            {
                player.SpriteName.text = Main.GameManager.CharacterType;
                player.SetSprite($"{Main.GameManager.CharacterType}.sprite");
            }
            
            Player = player;

            return Player as T;
        }

        else if (type == typeof(Enemy))
        {
            GameObject obj = Main.ResourceManager.Instantiate($"Enemy.prefab", pooling: true);
            obj.transform.position = position;

            Enemy enemy = obj.GetOrAddComponent<Enemy>();
            enemy.SetInfo(key);
            Enemies.Add(enemy);

            return enemy as T;
        }

        else if (type == typeof(Boss))
        {
            GameObject obj = Main.ResourceManager.Instantiate($"Boss.prefab", pooling: true);
            obj.transform.position = position;

            Enemy enemy = obj.GetOrAddComponent<Boss>();
            enemy.SetInfo(key);
            Enemies.Add(enemy);

            return enemy as T;
        }

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