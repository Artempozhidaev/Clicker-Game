using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Health_point = 1;
    Transform child;

    [System.Obsolete]
    void Start()
    {
        Health_point = Spawn_monsters.HP;
        child = gameObject.transform.FindChild("Health bar(Clone)");
    }
    private void Update()
    {
        child.localScale = new Vector3((Health_point*0.01f)+0.01f, child.localScale.y, child.localScale.z);
    }
}