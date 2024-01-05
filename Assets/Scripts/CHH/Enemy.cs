using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region Properties

    public EnemyData Data;
    public string _key;
    public int hp;
    public int currentHp;
    public float speed;
    public int damage;

    #endregion

    #region Fileds

    private Transform target;
    private NavMeshAgent _agent;
    private SpriteRenderer _enemySpriteRenderer;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    protected Animator _animator;

    #endregion

    #region Initialize

    private void Initialize()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void SetInfo(string key)
    {
        Initialize();
        _key = key;
        EnemyData enemy = Main.DataManager.Enemies.FirstOrDefault(e => e.Key == key).Value;
        _enemySpriteRenderer.sprite = Main.ResourceManager.GetResource<Sprite>($"{key}.sprite");
        _animator.runtimeAnimatorController = Main.ResourceManager.GetResource<RuntimeAnimatorController>($"{key}.animController");
        hp = enemy.HP;
        currentHp = hp;
        speed = enemy.Speed;
        _agent.speed = speed;
        damage = enemy.Damage;
    }

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        FindTarget();

        // 일정 시간마다 가장 가까운 플레이어를 찾아감
        StartCoroutine(UpdateTarget(5.0f));
    }

    private void Update()
    {
        if (target != null)
        {
            _agent.SetDestination(target.position);
            
            bool isTargetOnLeft = target.position.x < transform.position.x;
            _enemySpriteRenderer.flipX = isTargetOnLeft;
        }
    }

    #endregion

    #region Movement
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
    #endregion
}
