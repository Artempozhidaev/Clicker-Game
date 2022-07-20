using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn_monsters : MonoBehaviour
{
    public float time_to_spawn;

    private static float _timeLeft = 0f;
    public static bool _timerOn = false;

    public GameObject Ghost_brown, Ghost_green, Ghost_violet, Ghost_white;
    public GameObject Rabit_clye, Rabit_green, Rabit_red, Rabit_Yellow;
    public GameObject Slime_blue, Slime_green, Slime_red, Slime_Yellow;

    public GameObject mobs, health_bar;

    public GameObject Blur;

    public GameObject Tap_event;
    public GameObject Busters_events;

    public GameObject button_freeze, button_kill, button_home;

    public GameObject TMP_Lost_gO, TMP_Player_Score_gO, TMP_Score_lost, TMP_Score_gO, TMP_Score_num_gO, button_save_record;
    public TextMeshProUGUI TMP_Score_num, TMP_Player_Score;


    public static int HP = 1;
    public static int Monster_n = 0;
    public static int Score;

    public static int plus = 0;

    public static void Clear()
    {
        HP = 1;
        Monster_n = 0;
        Score = 0;
        _timeLeft = 0f;
        _timerOn = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        _timeLeft = time_to_spawn;
        _timerOn = true;

    }

    void SpawnMap()
    {
        float VectorX = Random.Range(-153, 153);
        float VectorZ = Random.Range(-255, 255);

        Vector3 position_mob = new Vector3(VectorX/100,0,VectorZ/100);
        Vector3 position_HP = new Vector3(VectorX/100,0.4f,VectorZ/100);

        float VectorY = Random.Range(-9, 9);
        float VectorW = Random.Range(-9, 9);

        int M = Random.Range(0, 13);

        Quaternion quaternion = new Quaternion(0, VectorY / 100, 0, VectorW/100);

        spawn_mob(M, position_mob, position_HP, quaternion);

        Monster_n++;
    }

    void spawn_mob(int F, Vector3 position_monster, Vector3 position_heath_bar, Quaternion quaternion)
    {
        
        switch (F)
        {
            case (0):
                {
                    GameObject Monster = Instantiate(Ghost_brown, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (1):
                {
                    GameObject Monster = Instantiate(Ghost_green, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (2):
                {
                    GameObject Monster = Instantiate(Ghost_violet, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (3):
                {
                    GameObject Monster = Instantiate(Ghost_white, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (4):
                {
                    GameObject Monster = Instantiate(Rabit_clye, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (5):
                {
                    GameObject Monster = Instantiate(Rabit_green, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (6):
                {
                    GameObject Monster = Instantiate(Rabit_red, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (7):
                {
                    GameObject Monster = Instantiate(Rabit_Yellow, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (8):
                {
                    GameObject Monster = Instantiate(Slime_blue, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (9):
                {
                    GameObject Monster = Instantiate(Slime_blue, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (10):
                {
                    GameObject Monster = Instantiate(Slime_green, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (11):
                {
                    GameObject Monster = Instantiate(Slime_red, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
            case (12):
                {
                    GameObject Monster = Instantiate(Slime_Yellow, position_monster, quaternion, mobs.transform);
                    GameObject Health_bar = Instantiate(health_bar, position_heath_bar, quaternion, Monster.transform);
                    break;
                }
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time_to_spawn;
                _timerOn = false;
            }
        }
        int A = int.Parse(TMP_Score_num.text);

        if (Score != A)
        {
            Score = A;
            plus++;
        }

        if (plus > 9)
        {
            HP++;
            Monster_walk.Speed = Monster_walk.Speed * 1.05f;
            time_to_spawn = time_to_spawn * 0.95f;
            plus = 0;
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            if (Monster_n != 10)
                SpawnMap();
            else
            {
                Lost_screen();
            }
            _timeLeft = time_to_spawn;
        }
            
    }
    void Lost_screen()
    {
        TMP_Player_Score.text = Score.ToString();
        
        Tap_event.SetActive(false);

        button_freeze.SetActive(false);
        button_kill.SetActive(false);
        button_home.SetActive(false);

        TMP_Score_gO.SetActive(false);
        TMP_Score_num_gO.SetActive(false);

        Blur.SetActive(true);

        button_save_record.SetActive(true);
        TMP_Player_Score_gO.SetActive(true);
        TMP_Score_lost.SetActive(true);
        TMP_Lost_gO.SetActive(true);

        Busters._isLost = true;
    }
}
