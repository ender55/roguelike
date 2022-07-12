using System;
using UnityEngine;

[Serializable]
public class MovementToEntity : Movement
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform targetTransform;

    public override void Move()
    {
        if (targetTransform)
        {
            rigidbody2D.AddForce(
                (new Vector2(targetTransform.position.x, targetTransform.position.y)
                 - rigidbody2D.position).normalized * MoveSpeed);
        }
    }
}