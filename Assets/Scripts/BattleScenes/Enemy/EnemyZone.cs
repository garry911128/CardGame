using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public DiscardPile discardPile;
    public DeckManager deckManager;
    public Player player;
    public UIManager uiManager;
    public PlayerShieldDisplay PSD;
    public GameObject slash;
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        // 使用保存的卡牌信息进行伤害处理
        Enemy enemy = GetComponent<Enemy>();
        if (enemy != null && drag.cardInfo != null)
        {
            if (drag.cardInfo.No == 1) // 執行造成傷害的操作
            {
                int damage = drag.cardInfo.damage; // 使用保存的卡牌信息获取伤害值
                int cost = drag.cardInfo.cost;  // 使用保存的卡牌信息获取能量消耗值
                bool energyConsumed = deckManager.ConsumeEnergy(cost);
                if (energyConsumed)
                {                   
                    enemy.TakeDamage(damage);
                    slash.gameObject.SetActive(true);
                    Tehe showAndHideScript = slash.GetComponent<Tehe>();
                    if (showAndHideScript != null)
                    {
                        showAndHideScript.ShowAndHide();
                    }
                    if (drag != null)
                    {
                        drag.parentToReturnTo = discardPile.transform;
                    }                       
                }
                else
                {
                    uiManager.ShowEnergyWarning();
                    //Debug.Log("No Energy la you dumbdumb");
                    // 能量不足，執行相應的提示或其他操作
                }
            }
            if (drag.cardInfo.No == 2) // 執行增加玩家護盾5點
            {
                int cost = drag.cardInfo.cost;
                bool energyConsumed = deckManager.ConsumeEnergy(cost);
                if (energyConsumed)
                {
                    player._shield += 5;
                    PSD.playerShieldDisplay();
                    if (drag != null)
                    {
                        drag.parentToReturnTo = discardPile.transform;
                    }
                }
                else
                {
                    uiManager.ShowEnergyWarning();
                    //Debug.Log("No Energy la you dumbdumb");
                    // 能量不足，執行相應的提示或其他操作
                }
            }
            if (drag.cardInfo.No == 3) // 執行回復能量
            {
                int cost = drag.cardInfo.cost;
                bool energyConsumed = deckManager.ConsumeEnergy(cost);
                if (energyConsumed)
                {
                    deckManager.currentEnergy++;
                    deckManager.currentEnergy++;
                    deckManager.currentEnergy++;
                    if (drag != null)
                    {
                        drag.parentToReturnTo = discardPile.transform;
                    }
                }
                else
                {
                    uiManager.ShowEnergyWarning();
                    //Debug.Log("No Energy la you dumbdumb");
                    // 能量不足，執行相應的提示或其他操作
                }
            }
            deckManager.UpdateEnergyFill();
        }
            


            

            
    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    
}
