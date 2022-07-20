using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Records : MonoBehaviour
{
    
    public static void Player_score(int Score)
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (Score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", Score);

        }
        
    }
}
