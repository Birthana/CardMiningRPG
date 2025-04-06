public class Enemy : Character
{
    public CardInfo loot;

    private void Awake()
    {
        AddToOnDeath(DropLoot);
    }

    public void DropLoot()
    {
        var hand = FindObjectOfType<Hand>();
        hand.Add(this, loot);
    }

    public void Attack(Character character)
    {
    }
}
