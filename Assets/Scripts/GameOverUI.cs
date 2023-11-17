using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject journalMenu;

    public GameObject thankYouContent;

    void Start()
    {
        journalMenu.SetActive(true);
        thankYouContent.SetActive(true);
    }



    public void ExitGame()
    {
        Application.Quit();
    }    
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

}
