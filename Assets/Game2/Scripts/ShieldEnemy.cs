using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    public BossEnemy bigBoss;
    public float lifeMax, life;
    public float spd;
    public bool isShielding, isProtecting;
    public float shieldTime, shieldTimeTarget;
    public Transform protectTarget;
    public float distanceShield;


    void ProtectEnemy(float shieldDistance, Transform targetToProtect)
    {
        Vector3 direction = targetToProtect.position - transform.position;
        direction.Normalize();
        
        Vector3 distance = targetToProtect.position - transform.position;
        //distance.Normalize();

        if (distance.magnitude <= shieldDistance)
        {
            bigBoss.ActivateShield();
            isShielding = true;
        }
        else
        {
            bigBoss.DeactivateShield();
            isShielding = false;
        }

        if (distance.magnitude > shieldDistance - 1.5f && isProtecting)
        {
            transform.position += direction * spd * Time.deltaTime;
        }
    }

    void ProtectTimer(Transform targetToProtect)
    {
        Vector3 direction = targetToProtect.position - transform.position;
        direction.Normalize();

        if (isShielding)
        {
            shieldTime -= Time.deltaTime;
        }
        if (shieldTime <= 0)
        {
            isProtecting = false;
            isShielding = false;
            transform.position -= direction * (spd + 3) * Time.deltaTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isProtecting = true;
        shieldTime = shieldTimeTarget;
    }

    // Update is called once per frame
    void Update()
    {
        ProtectEnemy(distanceShield, protectTarget);
        ProtectTimer(protectTarget);
    }
}
