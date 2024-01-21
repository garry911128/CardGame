using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCardManager : MonoBehaviour
{
    public Transform effectCardsContainer;
    public List<Transform> effectCards = new List<Transform>();
    public Player player;
    public Card card;

    void Start()
    {
        // 更改所有子物体的 Tag 为 "EffectCard"
        ChangeTags();
        // 寻找所有 Tag 为 "EffectCard" 的子物体
        FindEffectCards();
    }

    void ChangeTags()
    {
        foreach (Transform card in effectCardsContainer)
        {
            card.gameObject.tag = "EffectCard";
        }
    }

    void FindEffectCards()
    {
        foreach (Transform card in effectCardsContainer)
        {
            if (card.CompareTag("EffectCard"))
            {
                effectCards.Add(card);
            }
        }
    }

    void Update()
    {
        float healthPercentage = (float)player.currentHealth / player.maxHealth * 100f;

        if (effectCardsContainer.childCount == 5 && healthPercentage <= 85f)
        {
            if (effectCards.Count > 0)
            {
                int cardNo = effectCards[0].GetComponent<Card>().No;
                card.TriggerEffect(cardNo);
                RemoveEffectCard(0);
            }
        }

        if (effectCardsContainer.childCount == 4 && healthPercentage <= 70f)
        {
            if (effectCards.Count > 0)
            {
                int cardNo = effectCards[0].GetComponent<Card>().No;
                card.TriggerEffect(cardNo);
                RemoveEffectCard(0);
            }
        }

        if (effectCardsContainer.childCount == 3 && healthPercentage <= 55f)
        {
            if (effectCards.Count > 0)
            {
                int cardNo = effectCards[0].GetComponent<Card>().No;
                card.TriggerEffect(cardNo);
                RemoveEffectCard(0);
            }
        }

        if (effectCardsContainer.childCount == 2 && healthPercentage <= 40f)
        {
            if (effectCards.Count > 0)
            {
                int cardNo = effectCards[0].GetComponent<Card>().No;
                card.TriggerEffect(cardNo);
                RemoveEffectCard(0);
            }
        }

        if (effectCardsContainer.childCount == 1 && healthPercentage <= 25f)
        {
            if (effectCards.Count > 0)
            {
                int cardNo = effectCards[0].GetComponent<Card>().No;
                card.TriggerEffect(cardNo);
                RemoveEffectCard(0);
            }
        }
    }

    


    void RemoveEffectCard(int index)
    {
        if (index >= 0 && index < effectCards.Count)
        {
            Transform cardToRemove = effectCards[index];
            effectCards.RemoveAt(index);
            Destroy(cardToRemove.gameObject);
        }
    }
}
