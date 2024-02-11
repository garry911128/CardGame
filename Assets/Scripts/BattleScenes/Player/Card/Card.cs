using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int No;// 卡牌編號
    public string cardName;// 卡牌名称
    public int damage;
    public int cost;
    public Image CardImage;
    public TextMeshProUGUI cardText;
    public Text cardCost;
    public Enemy enemy;
    private Vector3 enlargedScale = new Vector3(2f, 2f, 2f);
    private Vector3 hoverOffset = new Vector3(0f, 40f, 0f); // 向上移动的偏移量

    private void Update()
    {
        if (No == 1)
        {
            
            cardText.text = "對敵人造成 <color=yellow>" + damage.ToString() + "</color> 點傷害";
            cardCost.text = cost.ToString();
        }
        if (No == 2)
        {

            cardText.text = "增加玩家 <color=yellow>5</color> 點護盾值";
            cardCost.text = cost.ToString();
        }
        if (No == 3)
        {

            cardText.text = "回復 <color=yellow>3</color> 點能量";
            cardCost.text = cost.ToString();
        }
    }

    public void TriggerEffect(int cardNo)
    {
        if (cardNo == 1)
        {
            enemy.TakeDamage(10);
        }
        else if (cardNo == 2)
        {
            enemy.TakeDamage(10);
        }
        
    }

    

}

