using System;
using UnityEngine;

public class CameraMoveState : IState
{
    private Transform transform;
    private float moveSpeed;
    //private Coroutine coroutine = null;

    public event Action<IState> StateExit;
    public StateMachine StateMachine { get; set; }

    public CameraMoveState(Transform transform, float moveSpeed)
    {
        this.transform = transform;
        this.moveSpeed = moveSpeed;
    }
    
    public void Enter()
    {
        
    }

    public void Exit()
    {

    }
}
