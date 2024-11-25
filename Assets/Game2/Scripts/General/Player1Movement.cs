using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float spd, scaleSpd;
    public Transform player, background;

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
        Vector3 minScale = new(2.5f, 2.5f, 2.5f);

        if (Input.GetKey(KeyCode.W))
        {
            background.localScale += scale;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            background.localScale -= scale;

            background.localScale = new Vector3(Mathf.Max(background.localScale.x, minScale.x), Mathf.Max(background.localScale.y, minScale.y), Mathf.Max(background.localScale.z, minScale.z));
        }
    }
}