using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSM : BaseEnemyController
{
    public IState CurrentState { get; private set; }
    public IState _previousState;

    bool _inTransition = false;

    public void ChangeState(IState newState)
    {
        // ensure we're ready for a new state
        if (CurrentState == newState || _inTransition)
            return;

        ChangeStateRoutine(newState);
    }

    public void RevertState()
    {
        if (_previousState != null)
            ChangeState(_previousState);
    }

    void ChangeStateRoutine(IState newState)
    {
        _inTransition = true;
        // begin our exit sequence, to prepare for new state
        if (CurrentState != null)
            CurrentState.Exit();
        // save our current state, in case we want to return to it
        if (_previousState != null)
            _previousState = CurrentState;

        CurrentState = newState;

        // begin our new Enter sequence
        if (CurrentState != null)
            CurrentState.Enter();

        _inTransition = false;
    }

    // pass down Update ticks to States, since they won't have a MonoBehaviour
    public void Update()
    {
        // simulate update ticks in states
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }

    public void FixedUpdate()
    {
        // simulate fixedUpdate ticks in states
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }

    public BossIdleState idleState;
    public BossAttackState attackState;
    public BossSpawnerState spawnerState;
    public BossAttack2State attack2State;

    [SerializeField] GameObject spawnee;
    [SerializeField] GameObject player;
    [SerializeField] private float timeToShoot = 1;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private int bulletCount = 5;

    public void Awake()
    {
        idleState = new BossIdleState(this, player, gameObject, attackRange);
        attackState = new BossAttackState(this, player, gameObject, attackRange, timeToShoot);
        spawnerState = new BossSpawnerState(this, player, gameObject, attackRange);
        attack2State = new BossAttack2State(this, player, gameObject, attackRange, timeToShoot/2);
    }

    public float GetHealthPercentage()
    {
        return _currentHealth/_health;
    }

    public void GetBigger()
    {
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void MoveToPlayer()
    {
       Move();
    }

    public void ShootNormalBullet()
    {
        EnemyBullet bullet = (EnemyBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.EnemyBullet);
        bullet.transform.position = transform.position + new Vector3(Random.Range(0,0.5f), Random.Range(0, 0.5f));
        bullet.SetDirection(_target.transform.position - transform.position);
    }

    public void ShootMultipleBullet()
    {
        for(int i=0;i<bulletCount;i++)
        {
            ShootNormalBullet();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(spawnee, gameObject.transform.position + new Vector3(Random.Range(0, 3f), Random.Range(0, 3f)), Quaternion.identity);
    }



    protected override void Start()
    {
        base.Start();
        ChangeState(idleState);
    }
}
