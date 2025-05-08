using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 _direction;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(_direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    // Set the direction for the bullet to move based on the player's rotation
    public void SetDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}