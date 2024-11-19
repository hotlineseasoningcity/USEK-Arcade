using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int currentHealth, health;

    void Awake()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health:" + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
    }
}
