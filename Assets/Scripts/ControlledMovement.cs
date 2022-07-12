using System;
using UnityEngine;

[Serializable]
public class ControlledMovement : Movement
{
    [SerializeField] private Rigidbody2D movingRigidbody2D;

    public event Action OnMove;

    public override void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        movingRigidbody2D.velocity = new Vector2(
            moveX * MoveSpeed * Time.fixedDeltaTime, 
            moveY * MoveSpeed * Time.fixedDeltaTime);
        OnMove?.Invoke();
    }
}
