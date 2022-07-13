using System.Collections;
using UnityEngine;

public class DamagedState : IState
{
    private DamageComponent damageComponent;
    private IDamageable damageable;
    private Coroutine coroutine;

    public DamagedState(IDamageable damageable, DamageComponent damageComponent)
    {
        this.damageable = damageable;
        this.damageComponent = damageComponent;
    }
    
    public StateMachine StateMachine { get; set; }
    
    public void Enter()
    {
        coroutine = CoroutineManager.Start(TakeDamage());
    }

    public void Exit()
    {
        if (coroutine != null)
        {
            CoroutineManager.Stop(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator TakeDamage()
    {
        damageable.Health.ChangeCurrentHp(-damageComponent.damage);
        yield return new WaitForSeconds(2f);
        StateMachine.DeleteState<DamagedState>();
    }
}
