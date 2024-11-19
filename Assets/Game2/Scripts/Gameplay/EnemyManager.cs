using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] enemySpawnPos;
    public EnemyBehavior enemy2;

    void Start()
    {
        enemy2.SpawnEnemy(enemySpawnPos);
    }

    void Update()
    {
        enemy2.Patrol();
    }
}
