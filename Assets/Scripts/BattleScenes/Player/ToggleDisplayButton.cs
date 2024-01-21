using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDisplayButton : MonoBehaviour
{
    public DeckDisplay deckDisplay;
    private bool isDisplayed = false;

    public void ToggleDisplay()
    {
        if (isDisplayed)
        {
            deckDisplay.ClearDisplay();
        }
        else
        {
            deckDisplay.DisplayDeck();
        }

        isDisplayed = !isDisplayed;
    }
}
