using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float spd;
    public Transform crosshair;

    public void Movement(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 direction = new(x, y);
        direction.Normalize();
        crosshair.position += spd * Time.deltaTime * direction;
    }
}
