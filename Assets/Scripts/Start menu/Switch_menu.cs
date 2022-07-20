using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch_menu : MonoBehaviour
{
    public GameObject button_play, button_etc, button_exit, button_back;

    public GameObject About_gO, HighScore_gO, HS_gO;
    public void Etc_click()
    {
        button_etc.SetActive(false);
        button_play.SetActive(false);
        button_exit.SetActive(false);
        HighScore_gO.SetActive(false);
        HS_gO.SetActive(false);

        button_back.SetActive(true);
        About_gO.SetActive(true);

    }

    public void Back_click()
    {
        button_etc.SetActive(true);
        button_play.SetActive(true);
        button_exit.SetActive(true);
        HighScore_gO.SetActive(true);
        HS_gO.SetActive(true);

        button_back.SetActive(false);
        About_gO.SetActive(false);
        
    }

    public void Exit_click()
    {
        Application.Quit();
    }
}
