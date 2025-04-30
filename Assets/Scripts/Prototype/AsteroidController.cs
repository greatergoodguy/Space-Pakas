using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 0.5f;

    void Start()
    {
        // Randomly rotate the asteroid
        float randomRotation = Random.Range(0, 360);
        transform.Rotate(0, 0, randomRotation);
    }

    void Update()
    {
        // Move the asteroid
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the asteroid and the bullet
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}