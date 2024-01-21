using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyFill : MonoBehaviour
{
    public Image energyFill; // 引用填充图像的 Image 组件

    public void SetHealth(float healthNormalized)
    {
        energyFill.fillAmount = healthNormalized; // 设置填充的量（0-1）
    }

    public void SetHealthFromRightToLeft(float healthNormalized)
    {
        energyFill.fillOrigin = 0; // 设置填充的起始位置从右边开始（1 表示从右边开始）
        energyFill.fillAmount = healthNormalized; // 设置填充的量（0-1）
    }
}
