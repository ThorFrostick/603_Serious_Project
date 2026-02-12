using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControls : MonoBehaviour
{
    public void OnStartClick() 
    {
        SceneManager.LoadScene("AppDec");
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
