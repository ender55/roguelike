using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    // TODO: сделать через IRotatable
    [SerializeField] private new Camera camera;
    
    private Rigidbody2D playerRigidbody;
    private Vector2 mousePosition;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - playerRigidbody.position;
        playerRigidbody.rotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
    }
}
