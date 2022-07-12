using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootDelay;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(projectilePrefab);
        }
    }

    private void Shoot(GameObject projectile)
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
