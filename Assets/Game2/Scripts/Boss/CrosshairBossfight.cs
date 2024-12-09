using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBossfight : MonoBehaviour
{
    public float speed, damage;
    public float limitX, limitY;
    public Transform screen;
    public Transform crosshair;
    IDamageable target;

    public void Movement(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 direction = new(x, y);
        direction.Normalize();
        crosshair.position += speed * direction * Time.deltaTime;

        /*if (crosshair.position.magnitude > limitX)
        {
            crosshair.position = new Vector3(-limitX, y, 0);
        }*/
    }

    void Attack(IDamageable enemy)
    {
        enemy.TakeDamage(damage);
    }

    private void Shoot()
    {
        if(target != null)
        {
            target.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            target = damageable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if(target == damageable)
            {
                target = null;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
