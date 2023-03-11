using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pausedMenu;
    public AudioMixer audioMixer;
   
   private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }                
        }
       
       
   }
    public void Resume()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Pause()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainMusic", value);
    }
      
}
