using UnityEngine;

public class BossSM : BaseEnemyController
{
    #region StateMachine
    public IState CurrentState { get; private set; }
    public IState _previousState;

    //đảm bảo từ một trạng thái chỉ chuyển được sang một trạng thái mới
    bool _inTransition = false;

    public void ChangeState(IState newState)
    {
        // chuyển trạng thái khi có trạng thái sẵn sàng
        if (CurrentState == newState || _inTransition)
            return;

        ChangeStateRoutine(newState);
    }

    public void RevertState()
    {
        // chuyển lại trạng thái trước đó
        if (_previousState != null)
            ChangeState(_previousState);
    }

    void ChangeStateRoutine(IState newState)
    {
        _inTransition = true;
        // gọi exit của trạng thái hiện tại, chuẩn bị chuyển trạng thái
        if (CurrentState != null)
            CurrentState.Exit();
        // lưu trạng thái trước để quay lại khi cần
        _previousState = CurrentState;

        CurrentState = newState;

        // enter trạng thái mới
        if (CurrentState != null)
            CurrentState.Enter();

        _inTransition = false;
    }

    // update cho các trạng thái, gọi tick vì state không phải là MonoBehaviour
    public void Update()
    {
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }

    public void FixedUpdate()
    {
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }
    #endregion
    public BossIdleState idleState;
    public BossAttackState attackState;
    public BossSpawnerState spawnerState;
    public BossAttack2State attack2State;
    
    [SerializeField] public GameObject spawnee;
    [SerializeField] public GameObject player;
    [SerializeField] public float timeToShoot = 1;
    [SerializeField] public float attackRange = 10f;
    [SerializeField] public int bulletCount = 5;

    public void Awake()
    {
        idleState = new BossIdleState(this);
        attackState = new BossAttackState(this);
        spawnerState = new BossSpawnerState(this);
        attack2State = new BossAttack2State(this);
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
