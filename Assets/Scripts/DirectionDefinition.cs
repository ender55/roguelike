using UnityEngine;

public class DirectionDefinition
{
    public void DefineDirection(Direction direction, PlayerInput playerInput)
    {
        direction.Dir = Vector2.zero;
        
        if (Input.GetKey(playerInput.moveDown))
        {
            direction.Dir += Vector2.down;
        } 
        else if (Input.GetKey(playerInput.moveUp))
        {
            direction.Dir += Vector2.up;
        } 
        if (Input.GetKey(playerInput.moveLeft))
        {
            direction.Dir += Vector2.left;
        } 
        else if (Input.GetKey(playerInput.moveRight))
        {
            direction.Dir += Vector2.right;
        }
        
        direction.Dir = direction.Dir.normalized;
    }
}
