using UnityEngine;

public class FrostBullet : Bullet
{
    [SerializeField] private FreezeComponent freezeComponent;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IMovable component))
        {
            if (other.gameObject.TryGetComponent(out IStateMachine statusMachine))
            {
                if (statusMachine.StateMachine.HasState<FrozenState>())
                {
                    //var currentState = statusMachine.StateMachine.GetState<FrozenState>();
                    statusMachine.StateMachine.DeleteState<FrozenState>();
                    statusMachine.StateMachine.SetState(new FrozenState(component, freezeComponent));
                }
                else
                {
                    statusMachine.StateMachine.SetState(new FrozenState(component, freezeComponent));
                }
            }
        }
        base.OnCollisionEnter2D(other);
    }
}
