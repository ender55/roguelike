using System;

public interface IState
{
    event Action<IState> StateExit;
    StateMachine StateMachine { get; set; }
    void Enter();
    void Exit();
}