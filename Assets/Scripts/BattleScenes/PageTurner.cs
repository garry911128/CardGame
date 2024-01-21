using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageTurner : MonoBehaviour
{
    public GameObject[] pages; // 存放說明書每頁的UI元素
    private int currentPage = 0; // 當前頁面編號

    void Start()
    {
        ShowPage(currentPage); // 顯示初始頁面
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            ShowPage(currentPage);
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
    }

    void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex); // 只顯示當前頁面，其他頁面隱藏
        }
    }
}
