using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSM : BaseEnemy
{
    public IState CurrentState { get; private set; }
    public IState _previousState;

    bool _inTransition = false;

    public void ChangeState(IState newState)
    {
        // ensure we're ready for a new state
        if (CurrentState == newState || _inTransition)
            return;

        if (newState is BossIdleState || newState is BossSpawnerState)
            enemyAnimator.SetTrigger("Idle");
        else
            enemyAnimator.SetTrigger("Attack");
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
    [SerializeField] private float timeToShoot = 1;
    [SerializeField] private float attackRange = 20f;
    [SerializeField] private int bulletCount = 5;

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }

    public void GetBigger()
    {
        gameObject.transform.localScale *= 1.25f;
    }

    public void MoveToPlayer()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 velocity = direction.normalized * speed;
        this.transform.position += velocity * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public void ShootNormalBullet()
    {
        AudioManager.Instance.PlaySoundFXClipWithID("enemy_shoot", transform, 1f);
        Vector3 directionNormalized = (player.transform.position - transform.position).normalized;

        // Tạo viên đạn từ prefab
        var bullet = BulletPooling.Instance.GetBullet(BulletType.EnemyBullet);
        bullet.transform.position = transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f));

        // Thiết lập hướng bay cho viên đạn
        bullet.SetDirection(directionNormalized);
    }

    public void ShootMultipleBullet()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            ShootNormalBullet();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(spawnee, gameObject.transform.position + new Vector3(Random.Range(5f, 10f), Random.Range(5f, 10f)), Quaternion.identity);
    }



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        idleState = new BossIdleState(this, player, gameObject, attackRange);
        attackState = new BossAttackState(this, player, gameObject, attackRange, timeToShoot);
        spawnerState = new BossSpawnerState(this, player, gameObject, attackRange);
        attack2State = new BossAttack2State(this, player, gameObject, attackRange * 1.5f, timeToShoot * 0.8f);

        currentHealth = maxHealth;
        ChangeState(idleState);

        timeToShoot = shootCoolDown;
    }
}
