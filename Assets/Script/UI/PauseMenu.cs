using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused=true;
    }
    void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused=false;
    }
}
