using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGameScript : MonoBehaviour
{

    private static bool isPause = false;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameMenu;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                
                Pause();
            }
            else
            {
                
                Continue();
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        isPause = false;
        GameMenu.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
        GameMenu.SetActive(false);
        PauseMenu.SetActive(true);
       
    }

    public void LoadLevel(String nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
