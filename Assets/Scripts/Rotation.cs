using System;
using UnityEngine;

[Serializable]
public class Rotation
{
    [SerializeField] private Transform transform;
    [SerializeField] private float turnSpeed;
    
    [HideInInspector] public Direction direction;

    public void LookAt()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.Euler(0, 0, Mathf.Atan2(direction.Dir.y, direction.Dir.x) * Mathf.Rad2Deg + 90f),
            turnSpeed * Time.deltaTime);
    }
}