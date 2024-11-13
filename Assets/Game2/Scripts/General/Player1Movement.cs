using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float spd, scaleSpd;
    public Transform player;

    SpriteRenderer sr;
    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void Movement(Vector2 input)
    {
        float x = input.x;
        Vector3 dir = new(x, 0);

        dir.Normalize();
        player.position += spd * Time.deltaTime * dir;

        Vector3 scale = new(scaleSpd, scaleSpd, scaleSpd);

        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += scale;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localScale -= scale;
        }
    }
}