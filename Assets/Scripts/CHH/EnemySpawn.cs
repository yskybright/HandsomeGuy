using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
    private Tilemap tilemap;

    private float blueSpawnInterval = 5f; // Blue 몬스터 스폰 간격(초)
    private float blackSpawnInterval = 7f; // Black 몬스터 스폰 간격(초)
    private float bossSpawnInterval = 60f; // 보스 몬스터 스폰 간격(초)

    private int blueInitialSpawnCount = 1; // 초기 Blue 몬스터 스폰 수
    private int blackInitialSpawnCount = 2; // 초기 Black 몬스터 스폰 수

    private int bossInitialSpawnCount = 1; // 초기 보스 몬스터 스폰 수
    private int bossSpawnCount = 1; // 현재까지 스폰된 보스 몬스터 수

    public void StartSpawn()
    {
        // Grid 오브젝트 찾기
        GameObject gridObject = GameObject.Find("Grid");

        if (gridObject != null)
        {
            // Grid 오브젝트에서 특정 자식 오브젝트(Grund) 찾기
            Transform grundTransform = gridObject.transform.Find("Grund");

            if (grundTransform != null)
            {
                // 찾은 자식 오브젝트에서 Tilemap 컴포넌트 찾기
                tilemap = grundTransform.GetComponent<Tilemap>();

                if (tilemap != null)
                {
                    StartCoroutine(SpawnEnemiesCoroutine());
                }
                else
                {
                    Debug.LogError("Tilemap component not found on Grund!");
                }
            }
            else
            {
                Debug.LogError("Grund object not found!");
            }
        }
        else
        {
            Debug.LogError("Grid object not found!");
        }
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        int currentBlueSpawnCount = blueInitialSpawnCount;
        int currentBlackSpawnCount = blackInitialSpawnCount;

        while (true)
        {
            // 현재 스폰 수만큼 Blue 몬스터 스폰
            for (int i = 0; i < currentBlueSpawnCount; i++)
            {
                Vector3Int randomTilePosition = GetRandomTilePosition();
                Main.ObjectManager.Spawn<Enemy>("Blue", tilemap.GetCellCenterWorld(randomTilePosition));
                yield return new WaitForSeconds(0.1f);
            }

            // 현재 스폰 수만큼 Black 몬스터 스폰
            for (int i = 0; i < currentBlackSpawnCount; i++)
            {
                Vector3Int randomTilePosition = GetRandomTilePosition();
                Main.ObjectManager.Spawn<Enemy>("Black", tilemap.GetCellCenterWorld(randomTilePosition));
                yield return new WaitForSeconds(0.1f);
            }

            // 1분마다 보스 몬스터 스폰
            if (Time.time % bossSpawnInterval == 0)
            {
                Vector3Int randomTilePosition = GetRandomTilePosition();
                Main.ObjectManager.Spawn<Enemy>("Boss", tilemap.GetCellCenterWorld(randomTilePosition));
                bossSpawnCount++;
            }

            // 시간이 지날 때마다 몬스터 수 증가
            currentBlueSpawnCount++;
            currentBlackSpawnCount++;

            yield return new WaitForSeconds(1f); // 1초 대기
        }
    }

    private Vector3Int GetRandomTilePosition()
    {
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int randomPosition = new Vector3Int(Random.Range(bounds.x, bounds.x + bounds.size.x), Random.Range(bounds.y, bounds.y + bounds.size.y), 0);
        return randomPosition;
    }
}
