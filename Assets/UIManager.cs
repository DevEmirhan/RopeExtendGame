using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject startPage;
    public GameObject winPage;
    public GameObject losePage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlay()
    {
        GameManager.Instance.StartGame();
        closeAllPages();
    }
    public void closeAllPages()
    {
        startPage.SetActive(false);
        winPage.SetActive(false);
        losePage.SetActive(false);
    }
    public void Win()
    {
        closeAllPages();
        winPage.SetActive(true);
    }
    public void Lose()
    {
        closeAllPages();
        losePage.SetActive(true);
    }
}
