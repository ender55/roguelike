using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private BurnComponent burnComponent;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable component))
        {
            if (other.gameObject.TryGetComponent(out IStateMachine stateMachine))
            {
                if (stateMachine.StateMachine.HasState<BurningState>())
                {
                    stateMachine.StateMachine.DeleteState<BurningState>();
                    stateMachine.StateMachine.SetState(new BurningState(component, burnComponent));
                }
                else
                {
                    stateMachine.StateMachine.SetState(new BurningState(component, burnComponent));
                }
            }
        }
        base.OnCollisionEnter2D(other);
    }
}