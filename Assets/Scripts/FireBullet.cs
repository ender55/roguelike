using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private BurnComponent burnComponent;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable component))
        {
            if (other.gameObject.TryGetComponent(out IStateMachine statusMachine))
            {
                if (statusMachine.StateMachine.HasState<BurningState>())
                {
                    statusMachine.StateMachine.DeleteState<BurningState>();
                    statusMachine.StateMachine.SetState(new BurningState(component, burnComponent));
                }
                else
                {
                    statusMachine.StateMachine.SetState(new BurningState(component, burnComponent));
                }
            }
        }
        base.OnCollisionEnter2D(other);
    }
}