using UnityEngine;

public class Petal : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), 5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDirection(transform.up);
    }

}
