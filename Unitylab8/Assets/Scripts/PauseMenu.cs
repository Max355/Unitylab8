using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseCanvas;

    void Start()
    {
        Time.timeScale = 1f;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
            Cursor.lockState = CursorLockMode.Confined;
            
        }
    }

    public void Stop()
    {
        PauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        Paused = true;
        
        
    }

    public void Play()
    {
       PauseCanvas.SetActive(false);
       Time.timeScale = 1f;
       Paused = false;
       
    }

    public void MainMenuButton()
    {   
        int nextSceneIndex = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(nextSceneIndex);
        
        
    }
}
