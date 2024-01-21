using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldDisplay : MonoBehaviour
{
    public Transform shieldDisplay;
    public Enemy enemy;

    public void enemyShieldDisplay()
    {
        if(enemy.shield > 0)
        {
            shieldDisplay.gameObject.SetActive(true);
        }
        else
        {
            shieldDisplay.gameObject.SetActive(false);
        }
        
    }
    private void Update()
    {
        if (enemy.shield > 0)
        {
            shieldDisplay.gameObject.SetActive(true);
        }
        else
        {
            shieldDisplay.gameObject.SetActive(false);
        }
    }

}
