using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts.BattleScenes.Player
{
    public class Player : MonoBehaviour
    {
        private int maxHealth = PlayerConstants.MAX_PLAYER_HP;
        public int _shield = 0;
        public int currentHealth;
        public PlayerHealthBar healthBar;
        private DeckManager _deck;
        private List<Card> _handZone;
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
            if (_shield > 0)
            {
                if (damage >= _shield)
                {
                    damage -= _shield;
                    _shield = 0;
                }
                else
                {
                    _shield -= damage;
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

        public void DragCard(PointerEventData pointerEvent)
        {
            //this.transform.position = pointerEvent.position;
        }

        private void Die()
        {
            // 玩家死亡時的處理...
        }
    }
}