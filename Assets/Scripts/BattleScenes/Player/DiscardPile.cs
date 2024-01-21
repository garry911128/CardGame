using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardPile : MonoBehaviour
{
    public Text cardCountText;
    void Update()
    {
        UpdateCardCount();
    }

    // Update is called once per frame
    void UpdateCardCount()
    {
        int cardCount = transform.childCount;
        cardCountText.text = cardCount.ToString();
    }
}
