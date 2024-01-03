using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region Fileds

    private Transform target;
    private NavMeshAgent _agent;

    #endregion


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        FindTarget();

        // 일정 시간마다 가장 가까운 플레이어를 찾아감
        StartCoroutine(UpdateTarget(5.0f));
    }

    private void Update()
    {
        if (target != null)
        {
            _agent.SetDestination(target.position);
        }
    }

    private IEnumerator UpdateTarget(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            FindTarget();
        }
    }

    /// <summary>
    ///  플레이어가 여러명일때 가장 가까운 플레이어를 타겟팅
    /// </summary>
    private void FindTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {
            Transform closestPlayer = players[0].transform;
            float closestDistance = Vector3.Distance(transform.position, closestPlayer.position);

            for (int i = 1; i < players.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, players[i].transform.position);

                if (distance < closestDistance)
                {
                    closestPlayer = players[i].transform;
                    closestDistance = distance;
                }
            }

            target = closestPlayer;
        }
    }
}
