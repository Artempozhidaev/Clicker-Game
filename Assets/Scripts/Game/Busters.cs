using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Busters : MonoBehaviour
{
    public GameObject Mobs;
    public GameObject freeze_timer_gO;

    public TextMeshProUGUI TMP_score;
    public TextMeshProUGUI TMP_freeze;

    public static bool _isLost = false;

    private float timeLeft = 0f;
    private bool timerOn = false;

    public float freeze_time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                TMP_freeze.text = timeLeft.ToString().Substring(0,4);
                UpdateTimeText();
            }
            else
            {
                timerOn = false;
            }
        }
    }
    private void UpdateTimeText()
    {
        if (timeLeft < 0)
        {
            Spawn_monsters._timerOn = true;
            timerOn = false;
            freeze_timer_gO.SetActive(false);
        }

    }

    public void Freeze_click()
    {
        if (_isLost == false)
        {
            Spawn_monsters._timerOn = false;

            timeLeft = freeze_time;

            TMP_freeze.text = freeze_time.ToString();
            freeze_timer_gO.SetActive(true);

            timerOn = true;
        }
        
    }
    public void Kill_click()
    {
        if (_isLost == false)
        {
            foreach (Transform child in Mobs.transform)
            {
                Destroy(child.gameObject);
                Spawn_monsters.Score++;
                Spawn_monsters.plus++;
                Spawn_monsters.Monster_n = 0;
                TMP_score.text = Spawn_monsters.Score.ToString();
            }
        }

    }
}
