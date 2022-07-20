using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tap : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
    public int Score;

    void FixedUpdate()
    {
        try
        {
            if (Input.GetMouseButtonDown(0))
            {
                var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(Ray, out RaycastHit hit) && (hit.collider.CompareTag("Monster")))
                {
                    hit.collider.gameObject.GetComponent<Health>().Health_point--;
                    if (hit.collider.gameObject.GetComponent<Health>().Health_point <= 0)
                    {
                        Destroy(hit.collider.gameObject);
                        Spawn_monsters.Score++;
                        textmeshPro.text = Spawn_monsters.Score.ToString();
                        Spawn_monsters.Monster_n--;
                    }
                }
            }
        }
        catch
        {

        }
    }
}
