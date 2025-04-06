using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "CardInfo/Attack")]
public class Attack : CardInfo, IActionCard, IHasRange
{
    public int energyCost;

    public int GetRange() { return GetCharacter().ATTACK_RANGE; }

    public void SpawnIndicator(RangeIndicator indicator)
    {
        indicator.Spawn(GetCharacter().transform.position, GetRange());
    }

    public int GetEnergy() { return energyCost; }

    public bool CanPlay(Ground ground, RangeIndicator rangeIndicator)
    {
        var positionToAttack = ground.GetClosetTilePosition(Mouse.GetMousePosition());
        var inRange = rangeIndicator.IsInRange(positionToAttack);
        var hasTarget = HasTargetAt(Mouse.GetMousePosition());
        var hasEnergy = GetCharacter().GetCurrentEnergy() >= GetEnergy();
        return inRange && hasTarget && hasEnergy;
    }
 
    private bool HasTargetAt(Vector3 position)
    {
        return GetTargetAt(position) != null;
    }

    private IDamageable GetTargetAt(Vector3 position)
    {
        foreach (var hit in Raycast.GetHitsAt(position))
        {
            if (hit)
            {
                var target = hit.transform.GetComponent<IDamageable>();
                if (target != null)
                {
                    return target;
                }
            }
        }

        return null;
    }

    public void Action(Ground ground)
    {
        GetCharacter().DecreaseEnergy(GetEnergy());
        var positionToAttack = ground.GetClosetTilePosition(Mouse.GetMousePosition());
        var damageable = GetTargetAt(positionToAttack);
        GetCharacter().Attack(damageable);
    }
}
