using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
     public void Click()
    {
        if (SceneManager.GetActiveScene().name == "Scene_menu") 
        {
            SceneManager.LoadScene("Scene_game", LoadSceneMode.Single);
            Spawn_monsters.Clear();
            Busters._isLost = false;
        } 
        else
        {
            SceneManager.LoadScene("Scene_menu", LoadSceneMode.Single);
        }

    }
}
