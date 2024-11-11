using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public GameObject enemyPref, bulletPref;
    bool onShootingRange = false;

    public void SpawnEnemy(Transform[] spawnPos)
    {
        int randomI = Random.Range(0, spawnPos.Length);

        for (int i = 0; i < 4; i++)
        {
            _ = Instantiate(enemyPref, spawnPos[randomI].position, Quaternion.identity);
        }
    }

    protected virtual void Patrol(Transform[] patrolPos, Transform enemyPos, float enemySpd)
    {
        bool isPatrolling = true;
        int randomI = Random.Range(0, patrolPos.Length);

        while (isPatrolling)
        {
            Vector3 dir = patrolPos[randomI].position - enemyPos.position;
            dir.Normalize();
            enemyPos.position += enemySpd * Time.deltaTime * dir;

            if (Vector2.Distance(enemyPos.position, patrolPos[randomI].position) <= 0.4f)
            {
                isPatrolling = false;
                ChasePlayer(enemyPos, enemySpd, 10);
            }
            else _ = Random.Range(0, patrolPos.Length);
        }
    }

    void ChasePlayer(Transform enemyPos, float enemySpd, float chaseDis)
    {
        bool isChasing = true;

        while (isChasing)
        {
            Vector3 dir = player.position - enemyPos.position;
            dir.Normalize();
            enemyPos.position += enemySpd * Time.deltaTime * dir;

            if (Vector2.Distance(enemyPos.position, player.position) <= chaseDis)
            {
                onShootingRange = true;
                isChasing = false;
            }
        }
    }

    protected virtual void Shoot(float coolDown, Transform spawnBullet, float bulletForce)
    {
        float timer = 0;
        timer += Time.deltaTime;

        if (timer >= coolDown && onShootingRange)
        {
            GameObject newBullet = Instantiate(bulletPref, spawnBullet.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * bulletForce, ForceMode2D.Impulse);

            Destroy(newBullet, 1.5f);
        }
    }

    protected virtual void TakeDamage(int dmg, GameObject enemy)
    {
        int hp = 2;
        int currentHp = hp;

        currentHp -= dmg;

        if (currentHp < 1)
        {
            enemy.SetActive(false);
        }
    }
}
