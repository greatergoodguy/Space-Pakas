using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    void Start()
    {
        // Destroy the bullet after 2 seconds to prevent memory issues
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        // Move the bullet in the player's facing direction (transform.up)
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    // Set the direction for the bullet to move based on the player's rotation
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}