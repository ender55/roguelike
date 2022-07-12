using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float lifeTime = 5f;
    
    private Rigidbody2D projectileRB;

    [HideInInspector] public int damage;
    
    IEnumerator Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        projectileRB.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy component))
        {
            component.Health.ChangeCurrentHp(-damage);
        }
        Destroy(gameObject);
    }
}
