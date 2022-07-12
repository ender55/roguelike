using System;
using UnityEngine;

[Serializable]
public class DirectionalMovement : Movement
{
    [SerializeField] private Rigidbody2D movingRigidbody2D;

    [HideInInspector] public Direction direction;

    public event Action OnMove;

    public override void Move()
    {
        movingRigidbody2D.velocity = direction.Dir * (MoveSpeed * Time.fixedDeltaTime);
        OnMove?.Invoke();
    }
}