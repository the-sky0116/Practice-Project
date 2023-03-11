using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Window : MonoBehaviour
{
    public GameObject OptionMenu;

    public void exit()
    {
        Application.Quit();
        Debug.Log("end game");
    }
    public void Playbtn()
    {
        SceneManager.LoadScene("House");
    }
    public void main()
    {
        SceneManager.LoadScene("menu");
    }
    public void ResumeGame()
    {
        OptionMenu.SetActive(false);
    }

}
