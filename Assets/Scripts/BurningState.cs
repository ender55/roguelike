using System.Collections;
using UnityEngine;

public class BurningState : IState
{
    private IDamageable damageable;
    private BurnComponent burnComponent;
    private Coroutine coroutine;
    
    public StateMachine StateMachine { get; set; }
    
    public BurningState(IDamageable damageable, BurnComponent burnComponent)
    {
        this.damageable = damageable;
        this.burnComponent = burnComponent;
    }

    public void Enter()
    {
        coroutine = CoroutineManager.Start(Burn());
    }

    public void Exit()
    {
        if (coroutine != null)
        {
            CoroutineManager.Stop(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator Burn()
    {
        for (int i = 0; i < burnComponent.burningTime * 2; i++)
        {
            yield return new WaitForSeconds(0.5f);
            damageable.Health.ChangeCurrentHp(-burnComponent.burningDamage);
        }
        StateMachine.DeleteState<BurningState>();
    }
}