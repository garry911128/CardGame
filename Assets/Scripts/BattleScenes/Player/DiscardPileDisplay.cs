using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiscardPileDisplay : MonoBehaviour
{
    public Transform discardPileObject; // Deck 物体的引用
    public Transform displayParent; // UI 元素的父级
    public Transform discardPileScroll;

    public void DisplayDeck()
    {
        discardPileScroll.gameObject.SetActive(false); // 隐藏显示区域

        List<Transform> cards = new List<Transform>();

        for (int i = 0; i < discardPileObject.childCount; i++)
        {
            Transform child = discardPileObject.GetChild(i);
            if (child.GetComponent<Card>() != null)
            {
                cards.Add(child);
            }
        }

        // 按照 Card 脚本中的 No 属性排序卡片
        cards.Sort((a, b) => a.GetComponent<Card>().No.CompareTo(b.GetComponent<Card>().No));

        foreach (Transform card in cards)
        {
            GameObject cardCopy = Instantiate(card.gameObject, displayParent);
            cardCopy.transform.SetParent(displayParent);
        }

        discardPileScroll.gameObject.SetActive(true); // 显示显示区域
    }
    public void ClearDisplay()
    {
        foreach (Transform child in displayParent)
        {
            Destroy(child.gameObject);
        }

        discardPileScroll.gameObject.SetActive(false);
    }
}
