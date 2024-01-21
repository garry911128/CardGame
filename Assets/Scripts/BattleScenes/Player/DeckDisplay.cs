using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeckDisplay : MonoBehaviour
{
    public Transform deckObject; // Deck 物体的引用
    public Transform displayParent; // UI 元素的父级
    public Transform deckScroll;

    public void DisplayDeck()
    {
        deckScroll.gameObject.SetActive(false); // 隐藏显示区域

        List<Transform> cards = new List<Transform>();

        for (int i = 0; i < deckObject.childCount; i++)
        {
            Transform child = deckObject.GetChild(i);
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

        deckScroll.gameObject.SetActive(true); // 显示显示区域
    }
    public void ClearDisplay()
    {
        foreach (Transform child in displayParent)
        {
            Destroy(child.gameObject);
        }

        deckScroll.gameObject.SetActive(false);
    }
}