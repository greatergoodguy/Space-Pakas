using UnityEngine;

public class PlayerControllerDeprecated : MonoBehaviour
{
    public float speed = 1f;            // Speed of the ship
    public float rotationSpeed = 180f;
    public float recoilForce = 2f;     // Recoil force applied to the ship when shooting
    public float maxSpeed = 4f;       // Maximum velocity of the ship
    public GameObject bulletPrefab;    // Reference to the bullet prefab

    private Rigidbody2D rb;            // Reference to the Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for forward movement input (up arrow key or W key)
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // Apply a forward impulse to move the ship forward
            ApplyForwardMovement();
        }

        // Rotate the player with arrow keys or 'A'/'D'
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotation);

        // Shoot bullet when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
            ApplyRecoil();
        }
    }

    // Apply forward movement by adding an impulse in the direction the player is facing
    void ApplyForwardMovement()
    {
        // Apply an impulse force in the direction the player is facing
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    // Handle shooting the bullet
    void ShootBullet()
    {
        // Instantiate the bullet at the player position and with the same rotation
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        // Set the direction the bullet should move in
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDirection(transform.up); // Use transform.up for facing direction
    }

    // Apply recoil force to the player when shooting
    void ApplyRecoil()
    {
        // Apply an impulse force in the opposite direction of the ship's facing direction (negative y-axis)
        rb.AddForce(-transform.up * recoilForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        // Cap the velocity to ensure the ship doesn't exceed max speed
        CapVelocity();
    }

    // Cap the velocity to ensure the ship doesn't exceed max speed
    void CapVelocity()
    {
        // If the velocity magnitude exceeds maxSpeed, we limit it
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}