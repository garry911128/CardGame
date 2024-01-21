using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthFill; // 引用填充图像的 Image 组件

    public void SetHealth(float healthNormalized)
    {
        healthFill.fillAmount = healthNormalized; // 设置填充的量（0-1）
    }

    public void SetHealthFromRightToLeft(float healthNormalized)
    {
        healthFill.fillOrigin = 0; // 设置填充的起始位置从右边开始（1 表示从右边开始）
        healthFill.fillAmount = healthNormalized; // 设置填充的量（0-1）
    }
}
