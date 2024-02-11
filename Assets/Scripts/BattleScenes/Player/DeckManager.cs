using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public Transform deck; // 牌堆的区域
    public Transform hand; // 手牌区域
    public TurnManager turnManager;
    public PlayerEnergyFill playerEnergyFill;
    public int currentEnergy = 0; // 当前能量值
    public Text DeckCardCount;

    public List<Transform> cards = new List<Transform>();
    public int currentHandSlotIndex = 0;

    private void Start()
    {
        ChangeTags();
        currentEnergy = 3;
        ReturnCardsToDeck();
        ShuffleDeck();
        StartDrawingCards();
        //turnManager.StartTurn();
    }
    void ChangeTags()
    {
        foreach (Transform card in deck)
        {
            card.gameObject.tag = "cards";
        }
    }
    public void UpdateEnergyFill()
    {
        float energyNormalized = (float)currentEnergy / 3;
        playerEnergyFill.SetHealthFromRightToLeft(energyNormalized);
    }

    public void ShuffleDeck()
    {
        // 洗牌，将牌堆中的卡牌随机排序
        Debug.Log("sort in deck Manager");
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            Transform temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        // 重新排列卡牌的位置以反映洗牌后的顺序
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetSiblingIndex(i);
        }
    }

    public void StartDrawingCards()
    {
        StartCoroutine(DrawCardsCoroutine());
    }

    private IEnumerator DrawCardsCoroutine()
    {
        while (currentHandSlotIndex < 6 && cards.Count > 0)
        {
            yield return new WaitForSeconds(0.2f); // 每隔0.05秒抽一张牌

            DrawCard();
            // 如果手牌的数量已经到达6，可以考虑将 currentHandSlotIndex 重置为 0 或不再增加。
            currentHandSlotIndex++;
        }
    }
    public void DrawCard()
    {
        if (cards.Count > 0)
        {
            Transform drawnCard = cards[0];
            cards.RemoveAt(0);
            // 移动卡牌到手牌区域的底部
            drawnCard.SetParent(hand);
            drawnCard.SetAsLastSibling(); // 将卡牌放到最后，即手牌的底部
        }
    }

    public void ResetDeck()
    {
        // 重置牌堆，重新初始化并洗牌
        ShuffleDeck();
    }

    public List<Transform> GetCards()
    {
        return cards;
    }

    public void ReturnCardsToDeck()
    {
        // 找到所有带有 "cards" 标签的卡牌
        GameObject[] taggedCards = GameObject.FindGameObjectsWithTag("cards");

        // 清空卡牌列表
        cards.Clear();

        // 将这些卡牌的Transform添加回cards列表
        foreach (GameObject card in taggedCards)
        {
            Transform cardTransform = card.transform;
            cards.Add(cardTransform);
            cardTransform.SetParent(deck);
            cardTransform.localPosition = Vector3.zero;
        }

        ShuffleDeck();
        currentHandSlotIndex = 0; // 重置手牌索引
    }
    public bool ConsumeEnergy(int amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            return true;
        }
        else
        {
            return false; // 当前能量不足以消耗
        }
    }
    public void UpdateCardCount()
    {
        int cardCount = transform.childCount;
        DeckCardCount.text = cardCount.ToString();
    }

    void Update()
    {
        UpdateCardCount();
    }
}