using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrueba : MonoBehaviour
{
    public Transform positionA, positionB;

    public float speed = 10;

    Transform enemyTransformPosition;

    public Vector2 direction;

    public float radio;

    public bool isRight = true;


    void Start()
    {
        enemyTransformPosition = transform;
    }

    void Update()
    {
        if (isRight)
        {
            direction = positionB.position - enemyTransformPosition.position;
        }
        else
        {
            direction = positionA.position - enemyTransformPosition.position;
        }
        if (direction.magnitude <= radio)
        {
            isRight = !isRight;
        }

        enemyTransformPosition.position += (Vector3)(direction.normalized * speed * Time.deltaTime);


    }
}
