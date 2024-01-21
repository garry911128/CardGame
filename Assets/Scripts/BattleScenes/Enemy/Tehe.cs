using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tehe : MonoBehaviour
{
    public GameObject objectToShowAndHide;
    public float displayTime = 0.5f; // 显示时间
    public float fadeDuration = 0.5f; // 渐变消失时间

    // 调用此方法以显示并隐藏 GameObject
    public void ShowAndHide()
    {
        StartCoroutine(ShowAndHideRoutine());
    }

    IEnumerator ShowAndHideRoutine()
    {
        // 显示 GameObject
        objectToShowAndHide.SetActive(true);

        // 等待指定的显示时间
        yield return new WaitForSeconds(displayTime);

        // 计算渐变消失的速度
        float fadeSpeed = 1.0f / fadeDuration;
        float t = 0.0f;
        Color initialColor = objectToShowAndHide.GetComponent<Renderer>().material.color;

        // 逐渐将 GameObject 渐变为透明
        while (t < 1.0f)
        {
            t += Time.deltaTime * fadeSpeed;
            Color newColor = initialColor;
            newColor.a = Mathf.Lerp(initialColor.a, 0.0f, t);
            objectToShowAndHide.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }

        // 隐藏 GameObject
        objectToShowAndHide.SetActive(false);
    }
}
