using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int chosenAction = -1; // -1 表示沒有選擇任何行動
    public int shield = 10;
    public int attack = 5;
    public int addShield = 5;
    public TextMeshProUGUI actionText;
    public EnemyHealthBar healthBar;
    public GameObject enemyMoveAttack;
    public GameObject enemyMoveDefense;

    private void Start()
    {
        HideMoveImage();
        ChooseAction();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void HideMoveImage()
    {
        enemyMoveAttack.SetActive(false);
        enemyMoveDefense.SetActive(false);
    }
    void UpdateHealthBar()
    {
        float healthNormalized = (float)currentHealth / maxHealth;
        healthBar.SetHealthFromRightToLeft(healthNormalized);
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
        Destroy(gameObject);
    }

    // 選擇敵人行動的方法
    public void ChooseAction()
    {
        chosenAction = Random.Range(0, 2); // 選擇一個行動（這裡假設有三個行動）
        DisplayChosenAction();
    }
    public void DisplayChosenAction()
    {
        switch (chosenAction)
        {
            case 0:
                string coloredText1 = "\u003Ccolor=#9E0000\u003E" + attack.ToString() + "\u003C/color\u003E";
                actionText.text = coloredText1;
                enemyMoveAttack.SetActive(true);
                break;
            case 1:
                string coloredText2 = "\u003Ccolor=#28A7E1\u003E" + addShield.ToString() + "\u003C/color\u003E";
                actionText.text = coloredText2;
                enemyMoveDefense.SetActive(true);
                break;
            // 可以繼續添加其他選擇的情況
            default:
                actionText.text = "Unknown Action";
                break;
        }
    }
}