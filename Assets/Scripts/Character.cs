using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public event Action<int> OnEnergyChange;
    public event Action<CardInfo> OnMine;
    public event Action OnDeath;
    public int HEALTH = 10;
    public int ENERGY = 100;
    public int MOVE_RANGE = 5;
    public int ATTACK_RANGE = 1;
    public int ATTACK_DAMAGE = 3;
    public int MINE_RANGE = 1;
    public int MINE_DAMAGE = 2;
    [SerializeField] private int currentHealth;
    [SerializeField] private int currentEnergy;
    private Deck deck;

    private void Awake()
    {
        var newDeck = GetComponentInChildren<Deck>();
        if (newDeck == null)
        {
            return;
        }

        newDeck.SetCharacter(this);
        deck = newDeck;
    }

    private void Start()
    {
        SetEnergy(ENERGY);
        currentHealth = HEALTH;
    }

    public Deck GetDeck() { return deck; }

    public void AddToOnMine(Action<CardInfo> function) { OnMine += function; }

    public void AddToOnDeath(Action function) { OnDeath += function; }

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
        currentHealth = Mathf.Max(0, currentHealth - damage);
        Debug.Log($"Take {damage} damage. Has {currentHealth} remaining.");
        if (currentHealth == 0)
        {
            Debug.Log($"{name} Died.");
            OnDeath?.Invoke();
        }
    }

    public void Mine(IMineable mineable)
    {
        var item = mineable.Mine(this);
        OnMine?.Invoke(item);
    }

    public int GetCurrentEnergy() { return currentEnergy; }

    public void DecreaseEnergy(int energyCost)
    {
        SetEnergy(Mathf.Max(0, currentEnergy - energyCost));
    }

    private void SetEnergy(int energy)
    {
        currentEnergy = energy;
        OnEnergyChange?.Invoke(energy);
    }
}
