using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }

    public int Health_point = 1;
    Transform child;
    private void Awake()
    {
        Instance = this;
    }

    public void MonsterClick()
    {
        Health_point--;
        if (Health_point <= 0)
        {
            gameObject.SetActive(false);

            Spawn_monsters.Instance.MonsterDead();

            Destroy(gameObject);
        }
        else
        {
            child.localScale = new Vector3(Health_point * 0.01f, child.localScale.y, child.localScale.z);
        }
    }
    [System.Obsolete]
    void Start()
    {
        Health_point = Spawn_monsters.HP;
        child = gameObject.transform.FindChild("Health bar(Clone)");
        child.localScale = new Vector3(Health_point * 0.01f, child.localScale.y, child.localScale.z);
    }
}