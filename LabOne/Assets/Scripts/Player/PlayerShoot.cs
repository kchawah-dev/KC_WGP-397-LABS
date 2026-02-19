using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is missing!");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("FirePoint is missing!");
            return;
        }

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}