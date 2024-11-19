using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float enemySpd, chaseRange, shootCoolDown, bulletForce;
    public Transform player, enemyPos, spawnBullet;
    public Transform[] patrolPos;
    public GameObject enemyPref, bulletPref;
    bool onShootingRange = false;
    int currentPatrolIndex;
    float timer = 0;

    public void SpawnEnemy(Transform[] spawnPos)
    {
        int randomI = Random.Range(0, spawnPos.Length);

        for (int i = 0; i < 4; i++)
        {
            _ = Instantiate(enemyPref, spawnPos[randomI].position, Quaternion.identity);
        }
    }

    public virtual void Patrol()
    {
        if (patrolPos.Length == 0) return;

        Vector3 direction = patrolPos[currentPatrolIndex].position - enemyPos.position;
        direction.Normalize();
        enemyPos.position += enemySpd * Time.deltaTime * direction;

        if (Vector3.Distance(enemyPos.position, patrolPos[currentPatrolIndex].position) <= 1f)
        {
            currentPatrolIndex++;
        }

        if (currentPatrolIndex >= patrolPos.Length)
        {
            currentPatrolIndex = 0;
        }
    }

    public void ChasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(enemyPos.position, player.position);

        if (distanceToPlayer >= chaseRange)
        {
            onShootingRange = true;
            Vector3 direction = player.position - enemyPos.position;
            direction.Normalize();
            enemyPos.position += enemySpd * Time.deltaTime * direction;
        }
    }

    protected virtual void Shoot()
    {
        timer += Time.deltaTime;

        if (timer >= shootCoolDown && onShootingRange)
        {
            GameObject newBullet = Instantiate(bulletPref, spawnBullet.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-Vector2.up * bulletForce, ForceMode2D.Impulse);

            Destroy(newBullet, 1.5f);

            timer = 0;
        }
    }

    protected virtual void TakeDamage(int damage, GameObject enemy)
    {
        int hp = 2;
        int currentHp = hp;

        currentHp -= damage;

        if (currentHp < 1)
        {
            enemy.SetActive(false);
        }
    }
}
