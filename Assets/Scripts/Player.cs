using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable, IMovable, ITriggerable, IStateMachine
{
    [SerializeField] private Health health;
    [SerializeField] private DirectionalMovement movement;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Direction direction;
    [SerializeField] private Gun gun;

    private StateMachine stateMachine = new StateMachine();
    
    public Health Health => health;
    public Movement Movement => movement;
    public Direction Direction => direction;
    public PlayerInput PlayerInput => playerInput;
    public StateMachine StateMachine => stateMachine;

    public event Action OnDeath;
    
    private void OnEnable()
    {
        GameLinks.AddLink(this);
        health.SetCurrentHp(health.CurrentHp);
        health.OnZeroHp += Die;
    }
    
    private void OnDisable()
    {
        health.OnZeroHp -= Die;
        GameLinks.DeleteLink<Player>();
    }

    private void Start()
    {
        movement.direction = direction;
    }

    private void Update()
    {
       direction.SetDirection(playerInput);
       gun.Shoot(playerInput);
    }

    private void FixedUpdate()
    {
        movement.Move();
    }
    
    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}