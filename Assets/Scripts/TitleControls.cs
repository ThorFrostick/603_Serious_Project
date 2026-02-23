using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControls : MonoBehaviour
{
    public TextMeshProUGUI peaceDaysText;
    public GameObject explainPanel;
    public GameObject onboardPanel;
    
    public void OnStartClick() 
    {
        explainPanel.SetActive(true);
    }

    public void OnAcceptClick() 
    {
        onboardPanel.SetActive(true);
    }

    public void OnBeginClick() 
    {
        SceneManager.LoadScene("UIIntegrate");
    }

    public void OnQuitClick() 
    {
        Application.Quit();
    }

    public void OnReturnClick() 
    {
        SceneManager.LoadScene("TitleScreen");
    }

    private void Start()
    {
        if (peaceDaysText == null)
        {
            return;
        }
        peaceDaysText.text = $"Peace Has Been Kept For <color=#FF0000>{StaticGameData.peaceDays}</color> Days";
    }
}
