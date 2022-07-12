using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IMovable, IDamageable, IStateMachine, IRotatable
{
    [SerializeField] private Health health;
    [SerializeField] private DirectionalMovement movement;
    [SerializeField] private Direction direction;
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private Rotation rotation;
    [SerializeField] private DamageComponent damageComponent;
    
    private Player player;
    private StateMachine stateMachine = new StateMachine();

    public StateMachine StateMachine => stateMachine;
    public Health Health => health;
    public Movement Movement => movement;
    public Rotation Rotation => rotation;

    private void OnEnable()
    {
        health.OnZeroHp += Die;
    }

    private void OnDisable()
    {
        health.OnZeroHp -= Die;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        player = GameLinks.GetLink<Player>();
        if (player)
        {
            enemyAI.Initialize(player.transform);
        }
        movement.direction = direction;
        rotation.direction = direction;
    }

    private void Update()
    {
        StartCoroutine(UpdatePath());
        direction.SetDirection(enemyAI);
        rotation.LookAt();
    }

    private void FixedUpdate()
    {
        movement.Move();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator UpdatePath()
    {
        enemyAI.UpdatePath();
        yield return new WaitForSeconds(0.5f);
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player component))
        {
            if (!component.StateMachine.HasState<DamagedState>())
            {
                component.StateMachine.SetState(new DamagedState(component, damageComponent));
            }
        }
    }
}
