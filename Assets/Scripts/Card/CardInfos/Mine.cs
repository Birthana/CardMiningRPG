using UnityEngine;

[CreateAssetMenu(fileName = "Mine", menuName = "CardInfo/Mine")]
public class Mine : CardInfo, IActionCard, IHasRange
{
    public int GetRange() { return GetCharacter().MINE_RANGE; }

    public void SpawnIndicator(RangeIndicator indicator)
    {
        indicator.Spawn(GetCharacter().transform.position, GetRange());
    }

    public bool CanPlay(Mouse mouse, Ground ground, RangeIndicator rangeIndicator)
    {
        var positionToMine = ground.GetClosetTilePosition(mouse.GetMousePosition());
        var inRange = rangeIndicator.IsInRange(positionToMine);
        var hasTarget = HasTargetAt(mouse.GetMousePosition());
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

    public void Action(Mouse mouse, Ground ground)
    {
        var positionToMine = ground.GetClosetTilePosition(mouse.GetMousePosition());
        var mineable = GetTargetAt(positionToMine);
        GetCharacter().Mine(mineable);
    }
}
