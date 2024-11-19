using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float bulletForce;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    float timer;

    void Shoot()
    {
        timer += Time.deltaTime;

        if (timer <= 0.7f)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * bulletForce, ForceMode2D.Impulse);
            
            Destroy(newBullet, 1.5f);
            
            timer = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }
}
