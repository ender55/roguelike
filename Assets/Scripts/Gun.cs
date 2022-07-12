using System;
using UnityEngine;

[Serializable]
public class Gun
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int damage;
    
    public void Shoot()
    {
        bullet.damage = damage;
        GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public void Shoot(PlayerInput playerInput)
    {
        if (Input.GetKeyDown(playerInput.fire))
        {
            Shoot();
        }
    }
}