using UnityEngine;

public abstract class ADamagable : MonoBehaviour
{
    public int hp;
    public ResourceType dropType;

    public bool GetDamage(int damage)
    {
        hp -= damage;
        return hp <= 0;
    }
}
