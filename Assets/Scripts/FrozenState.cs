using System;
using System.Collections;
using UnityEngine;

public class FrozenState : IState
{
    private IMovable movable;
    private FreezeComponent freezeComponent;
    private Coroutine coroutine = null;

    public StateMachine StateMachine { get; set; }

    public event Action<IState> StateExit;
    
    public FrozenState(IMovable movable, FreezeComponent freezeComponent)
    {
        this.movable = movable;
        this.freezeComponent = freezeComponent;
    }
    
    public void Enter()
    {
        coroutine = CoroutineManager.Start(Freeze());
    }

    public void Exit()
    {
        if (coroutine != null)
        {
            CoroutineManager.Stop(coroutine);
            coroutine = null;
        }
        Unfreeze();
    }

    private IEnumerator Freeze()
    {
        movable.Movement.MoveSpeed *= 1 - (freezeComponent.slownessPower / 100);
        yield return new WaitForSeconds(freezeComponent.slownessTime);
        StateMachine.DeleteState<FrozenState>();
        //OnStateExit();
    }

    private void Unfreeze()
    {
        movable.Movement.MoveSpeed /= 1 - (freezeComponent.slownessPower / 100);
    }

    protected virtual void OnStateExit()
    {
        StateExit?.Invoke(this);
    }
}