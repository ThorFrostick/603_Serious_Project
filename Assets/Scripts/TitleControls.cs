using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControls : MonoBehaviour
{
    public TextMeshProUGUI peaceDaysText;
    public GameObject explainPanel;
    
    public void OnStartClick() 
    {
        explainPanel.SetActive(true);
    }

    public void OnAcceptClick() 
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
        peaceDaysText.text = $"Days Peace Has Been Kept For <color=#FF0000>{StaticGameData.peaceDays}</color> Days";
    }
}
