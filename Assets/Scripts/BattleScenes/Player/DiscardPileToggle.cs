using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPileToggle : MonoBehaviour
{
    public DiscardPileDisplay discardPileDisplay;
    private bool isDisplayed = false;

    public void ToggleDisplay()
    {
        if (isDisplayed)
        {
            discardPileDisplay.ClearDisplay();
        }
        else
        {
            discardPileDisplay.DisplayDeck();
        }

        isDisplayed = !isDisplayed;
    }
}
