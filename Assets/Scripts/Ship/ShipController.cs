using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private Rigidbody2D rb;

    public PlayerNumber playerNumber = PlayerNumber.Mock;
    PlayerInput_Base _playerInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = GetRandomColor();

        _playerInput = ManagerInput.I.GetPlayerInput(playerNumber);
    }
    
    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        // Apply forward movement
        // if (_playerInput.GetKeyForward())
        // {
        //     ApplyForwardMovement();
        // }

        // Apply rotation
        if (_playerInput.GetAxisHorizontal() != 0)
        {
            ApplyRotation(_playerInput.GetAxisHorizontal());
        }

        // Apply recoil force when shooting
        if (_playerInput.GetKeyFire() || _playerInput.GetKeyForward())
        {
            ShootBullet();
            ApplyRecoil();
        }
    }

    void ApplyForwardMovement()
    {
        rb.AddForce(transform.up * Constants.I.speed, ForceMode2D.Impulse);
    }

    void ApplyRotation(float rotationInput)
    {
        transform.Rotate(0, 0, rotationInput * Constants.I.rotationSpeed * Time.deltaTime);
    }

    void ApplyRecoil()
    {
        rb.AddForce(-transform.up * Constants.I.recoilForce, ForceMode2D.Impulse);
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
        if (rb.linearVelocity.magnitude > Constants.I.maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * Constants.I.maxSpeed;
        }
    }
}