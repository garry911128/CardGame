using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public DeckManager deckManager;
    public Enemy enemy;
    public Player player;
    public Text enemyHealth;
    public Text enemyShield;
    public Text playerEnergyText;
    public Text playerHealth;
    public Text playerShield;
    public TextMeshProUGUI energyWarningText;
    public float fadeDuration = 0.000001f; // 渐变持续时间

    public void ShowEnergyWarning()
    {
        energyWarningText.gameObject.SetActive(true);
        energyWarningText.text = "能量不足!!"; // 设置提示文本
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color originalColor = energyWarningText.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            energyWarningText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        energyWarningText.gameObject.SetActive(false); // 渐变结束后隐藏文本
    }
    void Update()
    {       
        if (enemy != null && enemyHealth != null)
        {
            enemyHealth.text = enemy.currentHealth.ToString() + '/' + enemy.maxHealth.ToString();
        }

        if (enemy != null && enemyShield != null)
        {
            enemyShield.text = enemy.shield.ToString();
        }

        if (player != null && playerHealth != null)
        {
            playerHealth.text = player.currentHealth.ToString() + '/' + PlayerConstants.MAX_PLAYER_HP.ToString();
        }

        if (player != null && playerShield != null)
        {
            playerShield.text = player._shield.ToString();
        }

        if (deckManager != null && playerEnergyText != null)
        {
            playerEnergyText.text = deckManager.currentEnergy.ToString();
        }
    }
}
