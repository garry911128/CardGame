using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int shield = 0;
    public int currentHealth;
    public PlayerHealthBar healthBar;
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    void UpdateHealthBar()
    {
        float healthNormalized = (float)currentHealth / maxHealth;
        healthBar.SetHealthFromRightToLeft(healthNormalized);
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            if (damage >= shield)
            {
                damage -= shield;
                shield = 0;
            }
            else
            {
                shield -= damage;
                damage = 0;
            }
        }

        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 玩家死亡時的處理...
    }
}
