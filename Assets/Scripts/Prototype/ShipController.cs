using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 180f;
    public float recoilForce = 2f;
    public float maxSpeed = 4f;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleMovement(bool moveForward, float rotationInput, bool isShooting)
    {
        // Apply forward movement
        if (moveForward)
        {
            ApplyForwardMovement();
        }

        // Apply rotation
        if (rotationInput != 0)
        {
            ApplyRotation(rotationInput);
        }

        // Apply recoil force when shooting
        if (isShooting)
        {
            ShootBullet();
            ApplyRecoil();
        }
    }

    void ApplyForwardMovement()
    {
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    void ApplyRotation(float rotationInput)
    {
        transform.Rotate(0, 0, rotationInput * rotationSpeed * Time.deltaTime);
    }

    void ApplyRecoil()
    {
        rb.AddForce(-transform.up * recoilForce, ForceMode2D.Impulse);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDirection(transform.up);
    }

    void FixedUpdate()
    {
        CapVelocity();
    }

    void CapVelocity()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}