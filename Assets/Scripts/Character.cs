using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public event Action<int> OnEnergyChange;
    public int ENERGY = 100;
    public int MOVE_RANGE = 5;
    public int ATTACK_RANGE = 1;
    public int ATTACK_DAMAGE = 3;
    public int MINE_RANGE = 1;
    public int MINE_DAMAGE = 2;
    [SerializeField] private int currentHealth;

    private void Awake()
    {
        var deck = GetComponentInChildren<Deck>();
        if (deck == null)
        {
            return;
        }

        deck.SetCharacter(this);
    }

    private void Start()
    {
        SetEnergy(ENERGY);
    }

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

    public int GetCurrentEnergy() { return currentHealth; }

    public void DecreaseEnergy(int energyCost)
    {
        SetEnergy(Mathf.Max(0, currentHealth - energyCost));
    }

    private void SetEnergy(int energy)
    {
        currentHealth = energy;
        OnEnergyChange?.Invoke(energy);
    }
}
