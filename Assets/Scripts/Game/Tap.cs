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
                    hit.collider.gameObject.GetComponent<Health>().MonsterClick();
                }
            }
        }
        catch
        {

        }
    }
}
