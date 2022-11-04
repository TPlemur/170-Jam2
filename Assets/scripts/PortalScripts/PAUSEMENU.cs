using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAUSEMENU : MonoBehaviour
{
    
    // Update is called once per frame
    public static bool isPaused = false;
    public GameObject pauseMenuUI;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }    
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;

    }
}
