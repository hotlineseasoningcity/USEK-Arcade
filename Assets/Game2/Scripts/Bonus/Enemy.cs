using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; 
    public Mapa mapa;
    private Vector2Int currentGridPosition; 
    private Vector2Int targetGridPosition;
    private float moveTimer;
    private float moveInterval = 1f;
    void Start() 
    { 
        currentGridPosition = new Vector2Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.z)); 
        SetNewTargetPosition(); 
    }
    void Update() 
    { 
        if (moveTimer <= 0) 
        { 
            MoveToTarget(); 
            moveTimer = moveInterval; 
        } 
        else 
        { 
            moveTimer -= Time.deltaTime; 
        } 
    }
  
    void MoveToTarget() 
    { 
        if (mapa.gridInt[targetGridPosition.x, targetGridPosition.y] != (int)GridType.notWalkable) 
        { 
            currentGridPosition = targetGridPosition; transform.position = new Vector2(currentGridPosition.x, currentGridPosition.y); 
            SetNewTargetPosition(); 
        } 
        else 
        { 
            SetNewTargetPosition(); 
        } 
    }
    void SetNewTargetPosition()
    {
        Vector2Int[] directions = new Vector2Int[] { new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(-1, 0), new Vector2Int(1, 0) };

        Vector2Int randomDirection = directions[Random.Range(0, directions.Length)]; 

        targetGridPosition = currentGridPosition + randomDirection;
        Debug.Log(targetGridPosition);
        if (targetGridPosition.x < 0 || targetGridPosition.x >= mapa.width || targetGridPosition.y < 0 || targetGridPosition.y >= mapa.height) 
        { 
            SetNewTargetPosition(); 
        }
    }

}
