using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "CardInfo/Move")]
public class Move : CardInfo, IActionCard, IHasRange
{
    public int GetRange() { return GetCharacter().MOVE_RANGE; }

    public void SpawnIndicator(RangeIndicator indicator)
    {
        indicator.SpawnWithCollision(GetCharacter().transform.position, GetRange());
    }

    public bool CanPlay(Mouse mouse, Ground ground, RangeIndicator rangeIndicator)
    {
        var positionToMove = ground.GetClosetTilePosition(mouse.GetMousePosition());
        var inRange = rangeIndicator.IsInRange(positionToMove);
        return inRange;
    }

    public void Action(Mouse mouse, Ground ground)
    {
        MoveToMousePosition(mouse, ground);
    }

    private void MoveToMousePosition(Mouse mouse, Ground ground)
    {
        var positionToMove = ground.GetClosetTilePosition(mouse.GetMousePosition());
        GetCharacter().Move(positionToMove);
    }
}
