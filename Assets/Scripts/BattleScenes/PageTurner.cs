using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageTurner : MonoBehaviour
{
    public GameObject[] pages; // �s�񻡩��ѨC����UI����
    private int currentPage = 0; // ��e�����s��

    void Start()
    {
        ShowPage(currentPage); // ��ܪ�l����
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
            pages[i].SetActive(i == pageIndex); // �u��ܷ�e�����A��L��������
        }
    }
}
