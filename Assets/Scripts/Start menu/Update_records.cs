using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Update_records : MonoBehaviour
{
    public TextMeshProUGUI tmp_score;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            tmp_score.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
