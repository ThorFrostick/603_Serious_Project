using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControls : MonoBehaviour
{
    [SerializeField]
    public GameObject explainPanel;

    public void OnStartClick() 
    {
        explainPanel.SetActive(true);
    }

    public void onAcceptClick() 
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

}
