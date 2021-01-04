using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void unpause()
    {
        paused = !paused;
    }
}
