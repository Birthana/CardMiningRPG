using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int MOVE_RANGE = 5;
    public int ATTACK_RANGE = 1;
    public int ATTACK_DAMAGE = 3;
    public int MINE_RANGE = 1;
    public int MINE_DAMAGE = 2;

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(ATTACK_DAMAGE);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Take {damage} damage.");
    }

    public void Mine(IMineable mineable)
    {
        mineable.Mine(this);
    }
}
