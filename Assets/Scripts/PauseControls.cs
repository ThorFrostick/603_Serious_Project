using UnityEngine;
using UnityEngine.UIElements;

public class PauseControls : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField]
    GameObject pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            if (!isPaused)
            {
                pause.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                pause.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }

    }
}
