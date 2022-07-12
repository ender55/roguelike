using System;
using UnityEngine;

[Serializable]
public class Direction
{
      [SerializeField] private Vector2 dir;

      public Vector2 Dir
      {
            get => dir;
            set
            {
                  dir = value;
                  OnDirectionChange?.Invoke();
            }
      }

      public event Action OnDirectionChange;
      
      public void SetDirection(PlayerInput playerInput)
      {
            dir = Vector2.zero;
        
            if (Input.GetKey(playerInput.moveDown))
            {
                  dir += Vector2.down;
            } 
            else if (Input.GetKey(playerInput.moveUp))
            {
                  dir += Vector2.up;
            } 
            if (Input.GetKey(playerInput.moveLeft))
            {
                  dir += Vector2.left;
            } 
            else if (Input.GetKey(playerInput.moveRight))
            {
                  dir += Vector2.right;
            }
        
            dir = dir.normalized;
            OnDirectionChange?.Invoke();
      }

      public void SetDirection(EnemyAI enemyAI)
      {
            dir = enemyAI.CalculatePath();
            OnDirectionChange?.Invoke();
      }
}
