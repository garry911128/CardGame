using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldDisplay : MonoBehaviour
{
    public Transform shieldDisplay;
    public Player player;
    public void playerShieldDisplay()
    {
        if (player._shield > 0)
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
        if (player._shield > 0)
        {
            shieldDisplay.gameObject.SetActive(true);
        }
        else
        {
            shieldDisplay.gameObject.SetActive(false);
        }
    }
}
