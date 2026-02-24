using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorPages : MonoBehaviour
{
    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;

    private int currentPage = 1;

    private void Start()
    {
        ShowPage(1);
    }

    public void NextPage()
    {
        currentPage = (currentPage == 1) ? 2 : 1;
        ShowPage(currentPage);
    }

    public void ShowPage(int page)
    {
        if (page1 != null) page1.SetActive(page == 1);
        if (page2 != null) page2.SetActive(page == 2);
    }
}
