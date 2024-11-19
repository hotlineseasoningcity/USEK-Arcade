using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBehavior
{
    public override void Patrol()
    {
        base.Patrol();
    }

    protected override void Shoot()
    {
       base.Shoot();
    }

    void Update()
    {
        ChasePlayer();
        Shoot();
    }
}
