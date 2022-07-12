using System;
using UnityEngine;

[Serializable]
public abstract class Movement
{
    [SerializeField] private float moveSpeed;

    public float MoveSpeed
    {
        get => moveSpeed;
        set
        {
            var newMoveSpeed = value;
            if (newMoveSpeed < 0)
            {
                newMoveSpeed = 0;
            }
            moveSpeed = newMoveSpeed;
            OnMoveSpeedChange?.Invoke();
        }
    }
    
    public event Action OnMoveSpeedChange;

    public abstract void Move();
}
