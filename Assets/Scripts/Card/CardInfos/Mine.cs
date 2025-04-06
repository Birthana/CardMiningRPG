using UnityEngine;

[CreateAssetMenu(fileName = "Mine", menuName = "CardInfo/Mine")]
public class Mine : CardInfo, IActionCard, IHasRange
{
    public int energyCost;

    public int GetRange() { return GetCharacter().MINE_RANGE; }

    public void SpawnIndicator(RangeIndicator indicator)
    {
        indicator.Spawn(GetCharacter().transform.position, GetRange());
    }

    public int GetEnergy() { return energyCost; }

    public bool CanPlay(Ground ground, RangeIndicator rangeIndicator)
    {
        var positionToMine = ground.GetClosetTilePosition(Mouse.GetMousePosition());
        var inRange = rangeIndicator.IsInRange(positionToMine);
        var hasTarget = HasTargetAt(Mouse.GetMousePosition());
        return inRange && hasTarget;
    }

    private bool HasTargetAt(Vector3 position)
    {
        return GetTargetAt(position) != null;
    }

    private IMineable GetTargetAt(Vector3 position)
    {
        foreach (var hit in Raycast.GetHitsAt(position))
        {
            if (hit)
            {
                var target = hit.transform.GetComponent<IMineable>();
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
        var positionToMine = ground.GetClosetTilePosition(Mouse.GetMousePosition());
        var mineable = GetTargetAt(positionToMine);
        GetCharacter().Mine(mineable);
    }
}
