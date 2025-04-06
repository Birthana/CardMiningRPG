using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "CardInfo/Move")]
public class Move : CardInfo, IActionCard, IHasRange
{
    public int energyCost;

    public int GetRange() { return GetCharacter().MOVE_RANGE; }

    public void SpawnIndicator(RangeIndicator indicator)
    {
        indicator.SpawnWithCollision(GetCharacter().transform.position, GetRange());
    }

    public int GetEnergy() { return energyCost; }

    public bool CanPlay(Ground ground, RangeIndicator rangeIndicator)
    {
        var positionToMove = ground.GetClosetTilePosition(Mouse.GetMousePosition());
        var inRange = rangeIndicator.IsInRange(positionToMove);
        return inRange;
    }

    public void Action(Ground ground)
    {
        GetCharacter().DecreaseEnergy(GetEnergy());
        MoveToMousePosition(ground);
    }

    private void MoveToMousePosition(Ground ground)
    {
        var positionToMove = ground.GetClosetTilePosition(Mouse.GetMousePosition());
        GetCharacter().Move(positionToMove);
    }
}
