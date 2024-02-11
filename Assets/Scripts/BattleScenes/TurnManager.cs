using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public DeckManager deckManager;
    public DiscardPile discardPile;
    public Transform hand;
    public Transform discardpile;
    public Enemy enemy;
    public EnemyShieldDisplay ESD;
    public Player player;

    // 在游戏开始或者新回合开始时调用

    public void StartTurn()
    {
        enemy.ChooseAction();
        if (deckManager.cards.Count == 0)
        {
            ReturnCardsFromDiscardPile();
            deckManager.StartDrawingCards();
         }        
    }

    public void ReturnCardsFromDiscardPile()
    {
        GameObject[] taggedCards = GameObject.FindGameObjectsWithTag("cards");

        foreach (GameObject card in taggedCards)
        {
            Transform cardTransform = card.transform;
            deckManager.cards.Add(cardTransform);
            cardTransform.SetParent(deckManager.deck);
            cardTransform.localPosition = Vector3.zero;
        }

        deckManager.ShuffleDeck(); // 洗牌
    }

    public void EndTurn()
    {
        int handCardCount = hand.childCount;
        for (int i = 0; i < handCardCount; i++)
        {
            Transform card = hand.GetChild(0); // 从0开始获取子物体
            MoveToDiscardPile(card);
        }
        switch (enemy.chosenAction)
        {
            case 0:
                // 執行敵人行動1的效果
                //Debug.Log("Enemy performs action 1");
                int damage = enemy.attack;
                player.TakeDamage(damage);
                break;
            case 1:
                // 執行敵人行動2的效果
                //Debug.Log("Enemy performs action 2");
                enemy.shield += enemy.addShield;
                break;
            //case 2:
                // 執行敵人行動3的效果
                //Debug.Log("Enemy performs action 3");
                //break;
            //default:
                //break;
        }
        player._shield = 0;
        enemy.HideMoveImage();
        enemy.chosenAction = -1;
        ESD.enemyShieldDisplay();
        deckManager.currentEnergy = 3;
        deckManager.currentHandSlotIndex = 0;
        deckManager.StartDrawingCards();
        deckManager.UpdateEnergyFill();
        StartTurn();


    }
    void MoveToDiscardPile(Transform card)
    {
        card.SetParent(discardpile);
    }
}
