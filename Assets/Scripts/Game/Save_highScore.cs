using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Save_highScore : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public void Save()
    {
        int score = int.Parse(Score.text);
        Records.Player_score(score);
    }
}
